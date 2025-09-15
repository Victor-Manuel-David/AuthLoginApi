using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AuthServer.Application.Auth;
using AuthServer.Domain.Entities;
using AuthServer.Infrastructure.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace AuthServer.Infrastructure.Auth;

public class JwtAuthService : IAuthService
{
    private readonly JwtOptions _options;

    public JwtAuthService(JwtOptions options) => _options = options;

    public LoginResult Login(User user, string username, string password)
    {
        if (user.Username != username || user.Password != password)
            throw new UnauthorizedAccessException("Invalid credentials");

        var handler = new JwtSecurityTokenHandler();
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.SigningKey));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var claims = new List<Claim>
        {
            new(JwtRegisteredClaimNames.Sub, user.Username),
            new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new("roles", string.Join(",", user.Roles))
        };

        var token = new JwtSecurityToken(
            issuer: _options.Issuer,
            audience: _options.Audience,
            claims: claims,
            notBefore: DateTime.UtcNow,
            expires: DateTime.UtcNow.AddSeconds(_options.ExpiresInSeconds),
            signingCredentials: creds
        );

        var jwt = handler.WriteToken(token);
        return new LoginResult(jwt, _options.ExpiresInSeconds);
    }
}
