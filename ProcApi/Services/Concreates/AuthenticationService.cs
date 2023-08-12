using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ProcApi.Configurations.Options;
using ProcApi.Data.ProcDatabase.Models;
using ProcApi.DTOs.Authentication;
using ProcApi.Repositories.Abstracts;
using ProcApi.Services.Abstracts;

namespace ProcApi.Services.Concreates;

public class AuthenticationService : IAuthenticationService
{
    private readonly IUserService _userService;
    private readonly IUserRepository _userRepository;
    private readonly JwtOptions _jwtOptions;
    private readonly int keySize = 128;
    private readonly int iteration = 350000;

    public AuthenticationService(IUserService userService,
        IUserRepository userRepository,
        IOptions<JwtOptions> jwtOptions)
    {
        _userService = userService;
        _userRepository = userRepository;
        _jwtOptions = jwtOptions.Value;
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

        var user = new User()
        {
            Login = dto.Login,
            FirstName = dto.FirstName,
            Gender = dto.Gender,
            UserPassword = passwordModel
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

        return await GenerateJwtToken(user);
    }

    private string GenerateHashPassword(string password, out byte[] salt)
    {
        salt = RandomNumberGenerator.GetBytes(keySize);

        var hash = Rfc2898DeriveBytes.Pbkdf2(
            Encoding.UTF8.GetBytes(password),
            salt,
            iteration,
            HashAlgorithmName.SHA512,
            keySize
        );

        return Convert.ToHexString(hash);
    }

    private bool VerifyPassword(string password, UserPassword userPassword)
    {
        var hashToCompare = Rfc2898DeriveBytes.Pbkdf2(password,
            Convert.FromHexString(userPassword.Salt),
            iteration,
            HashAlgorithmName.SHA512,
            keySize);

        return CryptographicOperations.FixedTimeEquals(hashToCompare,
            Convert.FromHexString(userPassword.PasswordHash));
    }

    private async Task<string> GenerateJwtToken(User user)
    {
        var claims = new Claim[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString())
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