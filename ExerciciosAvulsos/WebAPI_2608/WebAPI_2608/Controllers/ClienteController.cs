using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using WebAPI_2608.Core.Interface;
using WebAPI_2608.Core.Model;
using WebAPI_2608.Filters;

namespace WebAPI_2608.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Consumes("application/json")]
    [Produces("application/json")]
    [TypeFilter(typeof(LogResourceFilter))]
    public class ClienteController : ControllerBase
    {
        public IClienteService _clienteService;

        public ClienteController(IClienteService clienteService)
        {
            Console.WriteLine("Iniciando Cliente Controller");
            _clienteService = clienteService;
        }

        //GET
        [HttpGet("/cliente/consultar")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [TypeFilter(typeof(LogActionFilter))]
        //[TypeFilter(typeof(LogAuthorizationFilter))]
        [TypeFilter(typeof(LogTimeFilter))]
        public ActionResult<List<ClienteID>> ConsultarClientes()
        {
            Console.WriteLine("Iniciando");
            return  Ok(_clienteService.ConsultarClientes());
        }

        //GET por CPF
        [HttpGet("/cliente/consultar/{cpf}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [TypeFilter(typeof(LogTimeFilter))]
        public ActionResult<ClienteID> ConsultarClientesCPF(string cpf)
        {
            var cliente = _clienteService.ConsultarClientes(cpf);
            if (cliente == null)
                return NotFound();
            return Ok(cliente);
        }

        //POST
        [HttpPost("/cliente/inserir")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ServiceFilter(typeof(CPFNaoEstaDuplicadoActionFilter))]
        [TypeFilter(typeof(LogTimeFilter))]
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
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ServiceFilter(typeof(GaranteProdutoClienteActionFilter))]
        [TypeFilter(typeof(LogTimeFilter))]
        public ActionResult<List<Cliente>> Atualizar([FromRoute] long id, Cliente cliente)
        {
            if (!_clienteService.AlterarClientes(id, cliente))
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            return NoContent();
        }

        //DELETE
        [HttpDelete("/cliente/{id}/deletar")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ServiceFilter(typeof(GaranteProdutoClienteActionFilter))]
        [TypeFilter(typeof(LogTimeFilter))]
        public ActionResult<List<Cliente>> Deletar([FromRoute] long id)
        {
            if (!_clienteService.DeletarClientes(id))
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            return NoContent();
        }
    }
}