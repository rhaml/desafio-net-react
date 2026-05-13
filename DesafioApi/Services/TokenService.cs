using DesafioApi.Configurations;
using DesafioApi.Models;
using DesafioApi.Services.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DesafioApi.Services
{
    public class TokenService : ITokenService
    {

        public string GenerateToken(User user)
        {
            var keyBytes = Encoding.ASCII.GetBytes(JwtSettings.JwtKey);

            var claims = new[]
            {
                new Claim(ClaimTypes.Name, user.Username)
            };

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.UtcNow.AddHours(2),
                signingCredentials: new SigningCredentials(
                    new SymmetricSecurityKey(keyBytes),
                    SecurityAlgorithms.HmacSha256Signature
                )
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
