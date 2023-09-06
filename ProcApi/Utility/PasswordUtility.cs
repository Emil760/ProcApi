using System.Security.Cryptography;
using System.Text;
using ProcApi.Configurations.Options;
using ProcApi.Data.ProcDatabase.Models;

namespace ProcApi.Utility;

public static class PasswordUtility
{
    public static string GenerateHashPassword(string password, out byte[] salt, PasswordOptions passwordOptions)
    {
        salt = RandomNumberGenerator.GetBytes(passwordOptions.KeySize);

        var hash = Rfc2898DeriveBytes.Pbkdf2(
            Encoding.UTF8.GetBytes(password),
            salt,
            passwordOptions.Iteration,
            HashAlgorithmName.SHA512,
            passwordOptions.KeySize
        );

        return Convert.ToHexString(hash);
    }

    public static bool VerifyPassword(string password, UserPassword userPassword, PasswordOptions passwordOptions)
    {
        var hashToCompare = Rfc2898DeriveBytes.Pbkdf2(password,
            Convert.FromHexString(userPassword.Salt),
            passwordOptions.Iteration,
            HashAlgorithmName.SHA512,
            passwordOptions.KeySize);

        return CryptographicOperations.FixedTimeEquals(hashToCompare,
            Convert.FromHexString(userPassword.PasswordHash));
    }
}