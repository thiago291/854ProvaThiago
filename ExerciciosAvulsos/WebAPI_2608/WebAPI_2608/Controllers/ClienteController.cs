using Microsoft.AspNetCore.Mvc;
using WebAPI_2608.Repository;

namespace WebAPI_2608.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClienteController : ControllerBase
    {
        public List<Cliente> clientes { get; set; }
        public ClienteRepository _repositorycliente;

        public ClienteController(IConfiguration configuration)
        {
            clientes = new List<Cliente>();
            _repositorycliente = new ClienteRepository(configuration);
        }

        //GET
        [HttpGet("/cliente/consultar")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<List<Cliente>> Consultar()
        {
            return Ok(_repositorycliente.GetClientes());
        }

        //POST
        [HttpPost("/cliente/inserir")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Cliente> Inserir(Cliente cliente)
        {
            if(!_repositorycliente.InserirClientes(cliente))
                return BadRequest();
            return CreatedAtAction(nameof(Inserir), cliente);
        }

        //PUT
        [HttpPut("/cliente/{id}/atualizar")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<List<Cliente>> Atualizar([FromRoute] long id, Cliente cliente)
        {
            if (!_repositorycliente.AlterarClientes(id, cliente))
                return BadRequest();
            return NoContent();
        }

        //DELETE
        [HttpDelete("/cliente/{id}/deletar")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<List<Cliente>> Deletar([FromRoute] long id)
        {
            if (!_repositorycliente.DeletarClientes(id))
                return NotFound();
            return NoContent();
        }


    }
}