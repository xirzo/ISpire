using System.Security.Claims;
using System.Text;
using ISpire.Core.Entities;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using ISpire.Core.Helpers;

namespace ISpire.Core.Services;

public class JwtService
{
    public string GenerateJwtToken(Account account)
    {
        var claims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, account.Guid.ToString()),
            new Claim(ClaimTypes.Email, account.Email),
            new Claim(ClaimTypes.Name, account.Name),
        };

        var jwtKey = EnvironmentHelper.GetEnvironmentVariableOrFile("JWT_KEY");
        var issuer = EnvironmentHelper.GetEnvironmentVariableOrFile("JWT_ISSUER");
        var audience = EnvironmentHelper.GetEnvironmentVariableOrFile("JWT_AUDIENCE");

        if (string.IsNullOrEmpty(jwtKey) || string.IsNullOrEmpty(issuer) || string.IsNullOrEmpty(audience))
        {
            throw new InvalidOperationException("JWT_KEY or JWT_ISSUER or JWT_AUDIENCE environment variable is not set.");
        }

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: issuer,
            audience: audience,
            claims: claims,
            expires: DateTime.UtcNow.AddHours(2),
            signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
