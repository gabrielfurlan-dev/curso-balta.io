using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Furlan.dev.Models;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace Furlan.dev.Services
{
    public class TokenService
    {
        public string GenerateToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var key = Encoding.ASCII.GetBytes(Configuration.JwtKey);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(type:ClaimTypes.Name, value:"gabrielfurlan"),
                    new Claim(type:ClaimTypes.Role, value:"admin"),
                    new Claim(type:"fruta", value:"banana"),
                }),
                Expires = DateTime.UtcNow.AddHours(8),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}