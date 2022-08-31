using Microsoft.AspNetCore.Mvc;

namespace WebAPI_2608.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClienteController : ControllerBase
    {

        private readonly ILogger<ClienteController> _logger;

        public List<Cliente> clientes { get; set; }
        public List<string> nomesAleatorios = new()
        {
            "Stephany Oliveira",
            "Beatriz Cavalcanti",
            "Ana Lívia Nunes",
            "Evelyn da Cunha",
            "João Miguel Costa",
            "Pedro Lucas Rodrigues",
            "Calebe Fernandes",
            "Daniela Cavalcanti",
            "Felipe Ribeiro",
            "Cecília Fernandes"
        };
        readonly Random rnd = new();
        
        public ClienteController(ILogger<ClienteController> logger)
        {
            _logger = logger;
            
            clientes = Enumerable.Range(1, 10).Select(i => new Cliente
            {
                DataDeNascimento = DateTime.Now.AddYears(-18 - i),
                Nome = nomesAleatorios[i - 1],
                CPF = (99999999999 - rnd.NextInt64(9999999999, 99999999999)).ToString(),
                Idade = DateTime.Now.Year - DateTime.Now.AddYears(-18 - i).Year
            }).ToList();
        }

        //GET
        [HttpGet("/cliente/consultar")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<List<Cliente>> Consultar()
        {
            return Ok(clientes);
        }

        //GET
        [HttpGet("/cliente/{index}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Cliente> Consultar2(int index)
        {
            if (index >= clientes.Count || index < 0)
                return NotFound();
            return Ok(clientes[index]);
        }

        //POST
        [HttpPost("/cliente/inserir")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Inserir(Cliente cliente)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            clientes.Add(cliente);
            return CreatedAtAction(nameof(Inserir), cliente);
        }

        //PUT
        [HttpPut("/cliente/{index}/atualizar")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Atualizar([FromRoute] int index, Cliente cliente)
        {
            if (index >= clientes.Count || index < 0)
                return BadRequest();
            clientes[index] = cliente;
            return NoContent();
        }

        //DELETE
        [HttpDelete("/cliente/{index}/deletar")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Deletar([FromRoute] int index)
        {
            if (index >= clientes.Count || index < 0)
                return NotFound();
            clientes.RemoveAt(index);
            return NoContent();
        }
    }
}