using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using ProcApi.Application.DTOs.Authentication;
using ProcApi.Application.Services.Abstracts;
using ProcApi.Domain.Entities;
using ProcApi.Domain.Enums;
using ProcApi.Domain.Exceptions;
using ProcApi.Infrastructure.Data;
using ProcApi.Infrastructure.Options;
using ProcApi.Infrastructure.Repositories.Abstracts;
using ProcApi.Infrastructure.Utility;

namespace ProcApi.Application.Services.Concreates;

public class AuthenticationService : IAuthenticationService
{
    private readonly IUserService _userService;
    private readonly IUserRepository _userRepository;
    private readonly IUserSettingRepository _userSettingRepository;
    private readonly JwtOptions _jwtOptions;
    private readonly PasswordOptions _passwordOptions;
    private readonly UserOptions _userOptions;
    private readonly ProcDbContext _context;

    public AuthenticationService(IUserService userService,
        IUserRepository userRepository,
        IUserSettingRepository userSettingRepository,
        IOptions<JwtOptions> jwtOptions,
        IOptions<PasswordOptions> passwordOptions,
        IOptions<UserOptions> userOptions,
        ProcDbContext context)
    {
        _userService = userService;
        _userRepository = userRepository;
        _userSettingRepository = userSettingRepository;
        _jwtOptions = jwtOptions.Value;
        _passwordOptions = passwordOptions.Value;
        _userOptions = userOptions.Value;
        _context = context;
    }

    public async Task Register(RegistrationDto dto)
    {
        var isAlreadyExists = await _userService.AlreadyExists(dto.Login);

        if (isAlreadyExists)
            throw new Exception("User with login already exits");

        var hashPassword = PasswordUtility.GenerateHashPassword(dto.Password, out var salt, _passwordOptions);

        var passwordModel = new UserPassword
        {
            PasswordHash = hashPassword,
            Salt = Convert.ToHexString(salt),
            LastModified = DateTime.Now
        };

        var roles = GetDefaultRoles();

        foreach (var role in roles)
        {
            _context.Attach(role);
            _context.Entry(role).State = EntityState.Unchanged;
        }

        var userSetting = new UserSetting
        {
            Language = _userOptions.DefaultLanguage
        };

        var user = new User
        {
            Login = dto.Login,
            FirstName = dto.FirstName,
            Gender = dto.Gender,
            UserPassword = passwordModel,
            Roles = roles,
            UserSetting = userSetting
        };

        await _userRepository.InsertAsync(user);
    }

    public async Task<string> Login(LoginDto dto)
    {
        var user = await _userRepository.FindWithPasswordHashByLogin(dto.Login);

        if (user is null)
            throw new ValidationException("user not found");

        var passwordMatch = PasswordUtility.VerifyPassword(dto.Password, user.UserPassword, _passwordOptions);

        if (!passwordMatch)
            throw new ValidationException("wrong password");

        var permissions = await _userRepository.GetPermissionsUnionDelegatedPermissions(user.Id);
        var userSettings = await _userSettingRepository.GetByUserId(user.Id);

        return JwtUtility.GenerateJwtToken(user.Id, permissions, userSettings.Language, _jwtOptions);
    }

    private List<Role> GetDefaultRoles()
    {
        return new List<Role>
        {
            new() { Id = (int)Roles.User }
        };
    }
}