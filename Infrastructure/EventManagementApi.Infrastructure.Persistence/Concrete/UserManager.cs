using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using EventManagementApi.Core.Application.Interfaces;
using EventManagementApi.Core.Domain.Entities;
using EventManagementApi.Infrastructure.External.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace EventManagementApi.Infrastructure.Persistence.Concrete;

public class UserManager : IUserManager
{
    private readonly IClaimManager _claimManager;
    private readonly JwtSettings _jwtSettings;

    public UserManager(IClaimManager claimManager, IOptions<JwtSettings> jwtSettings)
    {
        _claimManager = claimManager;
        _jwtSettings = jwtSettings.Value;
    }

    public (string token, DateTime expireAt) GenerateTJwtToken(User user)
    {
        var claims = new List<Claim> { new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()) };
        claims.AddRange(_claimManager.GetUserClaims(user));
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Secret));
        var creadentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var expireAt = DateTime.UtcNow.AddHours(4).AddMinutes(_jwtSettings.ExpireAt);
        var token = new JwtSecurityToken
            (claims: claims,
            expires: expireAt,
            signingCredentials: creadentials
            );
        var tokenHandler = new JwtSecurityTokenHandler();

        return (tokenHandler.WriteToken(token), expireAt);
    }

    public int GetCurrentUserId()
    {
        return _claimManager.GetCurrentUserId();
    }
}
