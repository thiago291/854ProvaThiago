using Microsoft.AspNetCore.Mvc;
using Trabalho_Final_ProgWebIII.Core.Interface;

namespace Trabalho_Final_ProgWebIII.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TokenController : ControllerBase
    {
        public ITokenService _tokenService;

        public TokenController(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }

        //GET para o teste local
        [HttpGet]
        public IActionResult CreateToken(string nome)
        {
            return Ok(_tokenService.GenerateTokenEventos(nome,"admin"));
        }
    }
}
