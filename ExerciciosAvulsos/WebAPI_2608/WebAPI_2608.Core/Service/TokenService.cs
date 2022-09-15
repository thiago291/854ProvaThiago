using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace WebAPI_2608.Core.Service
{
    internal class TokenService
    {
        public IConfiguration _configuration;


        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GenerateTokenProdutos(string nome, string permissao)
        {
            var key = Encoding.ASCII.GetBytes(_configuration.GetValue<string>("secretKey"));

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = "APIClientes.com",
                Audience = "APIProdutos.com",
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, nome),
                    new Claim(ClaimTypes.Role, permissao),
                    new Claim("teste", "123")
                }),
                Expires = DateTime.UtcNow.AddMinutes(15),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
