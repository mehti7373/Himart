using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Core.Application.IServices;
using Core.Application.IServices.Models;
using Core.Domain.UserAggregate.ValueObjects;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Infrastructure.Security;


public class AuthService(IOptions<JwtSettings> authOptions) : IAuthService
{
    private readonly JwtSettings _authOptions = authOptions.Value;

    public TokenModel GetToken(string userName, Guid userId, UserRole role)
    {
        var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_authOptions.SecretKey));
        var signinCredential = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);



        var tokenOption = new JwtSecurityToken(
            issuer: _authOptions.Issuer,
            claims: new List<Claim>
            {
                    new Claim(ClaimTypes.Name, userName),
                    new Claim(ClaimTypes.NameIdentifier, userId.ToString()),
                    new Claim(ClaimTypes.Role, role.Name),
            },
            expires: DateTime.Now.AddDays(10),
            signingCredentials: signinCredential
        );

        var token = new JwtSecurityTokenHandler().WriteToken(tokenOption);
        var expiresTime = _authOptions.ExpirationMinutes; // دقیقه

        return new TokenModel(token, expiresTime);
    }

}
