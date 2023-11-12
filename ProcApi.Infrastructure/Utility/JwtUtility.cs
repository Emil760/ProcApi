using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;
using ProcApi.Domain.Entities;
using ProcApi.Domain.Enums;
using ProcApi.Domain.Models;
using ProcApi.Infrastructure.Constants;
using ProcApi.Infrastructure.Options;

namespace ProcApi.Infrastructure.Utility;

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

    public static UserInfoModel GetUserInfo(string? jwtToken)
    {
        if (jwtToken is null)
        {
            return new UserInfoModel
            {
                UserId = 0
            };
        }

        jwtToken = jwtToken.Replace("Bearer ", "");
        var handler = new JwtSecurityTokenHandler();
        var token = handler.ReadToken(jwtToken) as JwtSecurityToken;

        return new UserInfoModel
        {
            UserId = int.Parse(token?.Claims.Single(c => c.Type == JwtRegisteredClaimNames.Sub).Value)
        };
    }

    public static IEnumerable<Permissions> GetUserPermissions(string? jwtToken)
    {
        if (jwtToken is null)
            return Enumerable.Empty<Permissions>();

        jwtToken = jwtToken.Replace("Bearer ", "");
        var handler = new JwtSecurityTokenHandler();
        var token = handler.ReadToken(jwtToken) as JwtSecurityToken;

        return token.Claims
            .Where(c => c.Type == ClaimKeys.Permission)
            .Select(c => (Permissions)int.Parse(c.Value));
    }
}