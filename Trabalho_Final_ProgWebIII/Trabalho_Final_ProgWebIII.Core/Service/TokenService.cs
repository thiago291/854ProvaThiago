using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Trabalho_Final_ProgWebIII.Core.Interface;

namespace Trabalho_Final_ProgWebIII.Core.Service
{
    public class TokenService : ITokenService
    {
        public IConfiguration _configuration;

        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GenerateTokenEventos(string nome, string permissao)
        {
            var key = Encoding.ASCII.GetBytes(_configuration.GetValue<string>("secretKey"));

            
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Audience = "APIEvents.com",
                Issuer = "APIClientes.com",
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, nome),
                    new Claim(ClaimTypes.Role, permissao),
                    new Claim("teste", "123")
                }),
                Expires = DateTime.UtcNow.AddHours(4),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key), 
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
