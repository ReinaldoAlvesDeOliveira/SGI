using Domain.Models;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Extensions;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SGI.Configuration
{
    public static class AuthenticationConfig
    {
        public static string GenerateToken(IConfiguration config,Usuario user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var secret = config.GetValue<string>("Service:Secret");
            var key = Encoding.ASCII.GetBytes(secret);
            var newsClaim = new List<Claim> {
                new Claim(ClaimTypes.Name, user.Nome)
            };

            foreach (var item in user.UsuarioPerfis)
            {
                newsClaim.Add(new Claim(item.Perfil.TipoPerfil.GetDisplayName(),item.Perfil.TipoPerfil.GetDisplayName()));
            }
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(newsClaim),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
