using Microsoft.AspNetCore.Mvc;
using WebAPI_2608.Core.Interface;
using WebAPI_2608.Core.Model;

namespace WebAPI_2608.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClienteController : ControllerBase
    {
        public IClienteService _clienteService;

        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        //GET
        [HttpGet("/cliente/consultar")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<List<ClienteID>> ConsultarClientes()
        {
            return Ok(_clienteService.ConsultarClientes());
        }

        //POST
        [HttpPost("/cliente/inserir")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Cliente> Inserir(Cliente cliente)
        {
            if (!_clienteService.InserirClientes(cliente))
                return BadRequest();
            return CreatedAtAction(nameof(Inserir), cliente);
        }

        //PUT
        [HttpPut("/cliente/{id}/atualizar")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<List<Cliente>> Atualizar([FromRoute] long id, Cliente cliente)
        {
            if (!_clienteService.AlterarClientes(id, cliente))
                return BadRequest();
            return NoContent();
        }

        //DELETE
        [HttpDelete("/cliente/{id}/deletar")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<List<Cliente>> Deletar([FromRoute] long id)
        {
            if (!_clienteService.DeletarClientes(id))
                return NotFound();
            return NoContent();
        }
    }
}