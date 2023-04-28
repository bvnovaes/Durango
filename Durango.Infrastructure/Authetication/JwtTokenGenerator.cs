using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Durango.Application.Common.Interfaces.Authentication;
using Durango.Application.Common.Interfaces.Sevices;
using Durango.Domain.Entities;
using Durango.Infrastructure.Authetication;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Durango.Infrastructure.Authentication;

public class JwtTokenGenerator : IJwtTokenGenerator
{
    private readonly JwtSettings _jwtSettings;
    private readonly IDateTimeProvider _datetimeprovider;

    public JwtTokenGenerator(IDateTimeProvider datetimeprovider, IOptions<JwtSettings> jwtSettings)
    {
        _datetimeprovider = datetimeprovider;
        _jwtSettings = jwtSettings.Value;
    }

    public string GenerateToken(User User)
    {
        var signingCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Secret)), SecurityAlgorithms.HmacSha256);

        var claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Sub, User.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.GivenName, User.FirstName),
            new Claim(JwtRegisteredClaimNames.FamilyName, User.LastName),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        var securityToken = new JwtSecurityToken(issuer: _jwtSettings.Issuer, audience: _jwtSettings.Audience, expires: _datetimeprovider.UtcNow.AddMinutes(_jwtSettings.ExpiryMinutes), claims: claims, signingCredentials: signingCredentials);

        return new JwtSecurityTokenHandler().WriteToken(securityToken);
    }
}