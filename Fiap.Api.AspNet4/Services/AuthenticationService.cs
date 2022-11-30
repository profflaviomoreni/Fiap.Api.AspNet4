using Fiap.Api.AspNet4.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Fiap.Api.AspNet4.Services
{
    public class AuthenticationService
    {

        public static string GetToken(UsuarioModel usuarioModel)
        {
            byte[] secret = Encoding.ASCII.GetBytes(Settings.Secret);

            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();

            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, usuarioModel.NomeUsuario),
                    new Claim(ClaimTypes.Role, usuarioModel.Regra),
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials( new SymmetricSecurityKey(secret), SecurityAlgorithms.HmacSha256Signature)
            };

            SecurityToken token = handler.CreateToken(tokenDescriptor);

            return handler.WriteToken(token);

        }
    }
}
