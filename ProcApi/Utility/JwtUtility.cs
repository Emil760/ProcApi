using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using ProcApi.Configurations.Options;
using ProcApi.Constants;
using ProcApi.DTOs.User.Base;

namespace ProcApi.Utility;

public static class JwtUtility
{
    public static string GenerateJwtToken(int userId,
        IEnumerable<string> permissions,
        string localization,
        JwtOptions jwtOptions)
    {
        var claims = new List<Claim>
        {
            new(JwtRegisteredClaimNames.Sub, userId.ToString()),
            new(ClaimKeys.Localization, localization)
        };

        foreach (var permission in permissions)
            claims.Add(new Claim(ClaimKeys.Permission, permission));

        var signingCredentials = new SigningCredentials(
            new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(jwtOptions.SecretKey)),
            SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            jwtOptions.Issuer,
            jwtOptions.Audience,
            claims,
            null,
            DateTime.Now.AddMinutes(jwtOptions.ExpirationTime),
            signingCredentials);

        return new JwtSecurityTokenHandler()
            .WriteToken(token);
    }

    public static UserInfo GetUserInfo(string? jwtToken)
    {
        if (jwtToken is null)
        {
            return new UserInfo
            {
                UserId = 0
            };
        }

        jwtToken = jwtToken.Replace("Bearer ", "");
        var handler = new JwtSecurityTokenHandler();
        var token = handler.ReadToken(jwtToken) as JwtSecurityToken;

        return new UserInfo
        {
            UserId = int.Parse(token?.Claims.Single(c => c.Type == JwtRegisteredClaimNames.Sub).Value)
        };
    }
}