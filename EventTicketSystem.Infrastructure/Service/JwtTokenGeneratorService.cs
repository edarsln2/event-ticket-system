using EventTicketSystem.Entity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;

public class JwtTokenGeneratorService
{
    private readonly IConfiguration _config;

    public JwtTokenGeneratorService(IConfiguration config)
    {
        _config = config;
    }

    public string GenerateToken(User user)
    {
        var signingKey = _config["JwtConfig:SigningKey"];
        var issuer = _config["JwtConfig:Issuer"];
        var audience = _config["JwtConfig:Audience"];

        var claims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.Name, user.UserName)
        };

        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(signingKey));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var jwtSecurityToken = new JwtSecurityToken(
            issuer: issuer,
            audience: audience,
            claims: claims,
            expires: DateTime.UtcNow.AddDays(1),
            notBefore: DateTime.UtcNow,
            signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
    }
}
