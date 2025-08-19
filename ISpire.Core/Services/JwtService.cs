using System.Security.Claims;
using System.Text;
using ISpire.Core.Entities;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

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
        
        var jwtKey = Environment.GetEnvironmentVariable("JWT_KEY");
        var issuer = Environment.GetEnvironmentVariable("JWT_ISSUER");
        var audience = Environment.GetEnvironmentVariable("JWT_AUDIENCE");

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