using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ProcApi.Configurations.Options;
using ProcApi.Data.ProcDatabase;
using ProcApi.Data.ProcDatabase.Models;
using ProcApi.DTOs.Authentication;
using ProcApi.Enums;
using ProcApi.Repositories.Abstracts;
using ProcApi.Services.Abstracts;

namespace ProcApi.Services.Concreates;

//TODO cant attach entity throw UnitOfWork instead using context
public class AuthenticationService : IAuthenticationService
{
    private readonly IUserService _userService;
    private readonly IUserRepository _userRepository;
    private readonly JwtOptions _jwtOptions;
    private readonly PasswordOptions _passwordOptions;

    private readonly ProcDbContext _context;

    public AuthenticationService(IUserService userService,
        IUserRepository userRepository,
        IOptions<JwtOptions> jwtOptions,
        IOptions<PasswordOptions> passwordOptions,
        ProcDbContext context)
    {
        _userService = userService;
        _userRepository = userRepository;
        _jwtOptions = jwtOptions.Value;
        _passwordOptions = passwordOptions.Value;
        _context = context;
    }

    public async Task Register(RegistrationDto dto)
    {
        var isAlreadyExists = await _userService.AlreadyExists(dto.Login);

        if (isAlreadyExists)
            throw new Exception("User with login already exits");

        var hashPassword = GenerateHashPassword(dto.Password, out var salt);

        var passwordModel = new UserPassword()
        {
            PasswordHash = hashPassword,
            Salt = Convert.ToHexString(salt),
            LastModified = DateTime.Now
        };

        var roles = new Role[]
        {
            new() { Id = (int)Roles.User }
        };

        foreach (var role in roles)
        {
            _context.Attach(role);
            _context.Entry(role).State = EntityState.Unchanged;
        }

        var user = new User()
        {
            Login = dto.Login,
            FirstName = dto.FirstName,
            Gender = dto.Gender,
            UserPassword = passwordModel,
            Roles = roles
        };

        await _userRepository.InsertAsync(user);
    }

    public async Task<string> Login(LoginDto dto)
    {
        var user = await _userRepository.FindWithPasswordHashByLogin(dto.Login);

        if (user is null)
            throw new Exception("user not found");

        var passwordMatch = VerifyPassword(dto.Password, user.UserPassword);

        if (!passwordMatch)
            throw new Exception("wrong password");

        return GenerateJwtToken(user);
    }

    private string GenerateHashPassword(string password, out byte[] salt)
    {
        salt = RandomNumberGenerator.GetBytes(_passwordOptions.KeySize);

        var hash = Rfc2898DeriveBytes.Pbkdf2(
            Encoding.UTF8.GetBytes(password),
            salt,
            _passwordOptions.Iteration,
            HashAlgorithmName.SHA512,
            _passwordOptions.KeySize
        );

        return Convert.ToHexString(hash);
    }

    private bool VerifyPassword(string password, UserPassword userPassword)
    {
        var hashToCompare = Rfc2898DeriveBytes.Pbkdf2(password,
            Convert.FromHexString(userPassword.Salt),
            _passwordOptions.Iteration,
            HashAlgorithmName.SHA512,
            _passwordOptions.KeySize);

        return CryptographicOperations.FixedTimeEquals(hashToCompare,
            Convert.FromHexString(userPassword.PasswordHash));
    }

    private string GenerateJwtToken(User user)
    {
        var claims = new Claim[]
        {
            new(JwtRegisteredClaimNames.Sub, user.Id.ToString())
        };

        var signingCredentials = new SigningCredentials(
            new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_jwtOptions.SecretKey)),
            SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            _jwtOptions.Issuer,
            _jwtOptions.Audience,
            claims,
            null,
            DateTime.Now.AddMinutes(_jwtOptions.ExpirationTime),
            signingCredentials);

        return new JwtSecurityTokenHandler()
            .WriteToken(token);
    }
}