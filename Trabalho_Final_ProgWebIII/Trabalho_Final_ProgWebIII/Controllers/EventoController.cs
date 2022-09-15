using Microsoft.AspNetCore.Mvc;
using Trabalho_Final_ProgWebIII.Core.Interface;
using Trabalho_Final_ProgWebIII.Core.Model;
//using Trabalho_Final_ProgWebIII.Filters;

namespace Trabalho_Final_ProgWebIII.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Consumes("application/json")]
    [Produces("application/json")]
    //[TypeFilter(typeof(LogResourceFilter))]
    public class EventoController : ControllerBase
    {
        public IEventoService _eventoService;

        public EventoController(IEventoService eventoService)
        {
            Console.WriteLine("Iniciando Evento Controller");
            _eventoService = eventoService;
        }

        //GET
        [HttpGet("/evento/consultar")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        //[TypeFilter(typeof(LogActionFilter))]
        //[TypeFilter(typeof(LogAuthorizationFilter))]
        //[TypeFilter(typeof(LogTimeFilter))]
        public ActionResult<List<CityEvent>> ConsultarEvento()
        {
            Console.WriteLine("Iniciando");
            return Ok(_eventoService.ConsultarEvento());
        }

        //GET por título
        [HttpGet("/evento/consultar/{titulo}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        //[TypeFilter(typeof(LogTimeFilter))]
        public ActionResult<CityEvent> ConsultarEvento(string titulo)
        {
            var evento = _eventoService.ConsultarEventoPorTitulo(titulo);
            if (evento == null)
                return NotFound();
            return Ok(evento);
        }

        //GET por ID
        [HttpGet("/evento/consultar/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        //[TypeFilter(typeof(LogTimeFilter))]
        public ActionResult<CityEvent> ConsultarEvento(long id)
        {
            var evento = _eventoService.ConsultarEventoPorID(id);
            if (evento == null)
                return NotFound();
            return Ok(evento);
        }

        //POST
        [HttpPost("/evento/inserir")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[ServiceFilter(typeof(CPFNaoEstaDuplicadoActionFilter))]
        //[TypeFilter(typeof(LogTimeFilter))]
        public ActionResult<CityEvent> Inserir(CityEvent evento)
        {
            if (!_eventoService.InserirNovoEvento(evento))
                return BadRequest();
            return CreatedAtAction(nameof(Inserir), evento);
        }

        //PUT
        [HttpPut("/evento/{id}/atualizar")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //[ServiceFilter(typeof(GaranteEventoActionFilter))]
        //[TypeFilter(typeof(LogTimeFilter))]
        public ActionResult<List<CityEvent>> Atualizar([FromRoute] long id, CityEvent evento)
        {
            if (!_eventoService.AlterarEvento(id, evento))
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            return NoContent();
        }

        //DELETE
        [HttpDelete("/evento/{id}/deletar")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //[ServiceFilter(typeof(GaranteEventoActionFilter))]
        //[TypeFilter(typeof(LogTimeFilter))]
        public ActionResult<List<CityEvent>> Deletar([FromRoute] long id)
        {
            if (!_eventoService.DeletarEvento(id))
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            return NoContent();
        }
    }
}