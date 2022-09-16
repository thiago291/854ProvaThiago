using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Trabalho_Final_ProgWebIII.Core.Interface;
using Trabalho_Final_ProgWebIII.Core.Model;
using Trabalho_Final_ProgWebIII.Filters;

namespace Trabalho_Final_ProgWebIII.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Consumes("application/json")]
    [Produces("application/json")]
    public class EventReservationController : ControllerBase
    {
        public IEventReservationService _reservaService;

        public EventReservationController(IEventReservationService reservaService)
        {
            Console.WriteLine("Iniciando Reserva Controller");
            _reservaService = reservaService;
        }

        //GET por nome e t�tulo
        [HttpGet("/reserva/consultar")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Authorize(Roles = "admin,cliente")]
        public ActionResult<List<EventReservation>> ConsultarReserva(string nome, string titulo)
        {
            Console.WriteLine("Iniciando");
            return Ok(_reservaService.ConsultarReserva(nome, titulo));
        }

        //POST
        [HttpPost("/reserva/inserir")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Authorize(Roles = "admin,cliente")]
        [ServiceFilter(typeof(GaranteEventoReservaActionFilter))]
        public ActionResult<EventReservation> Inserir(EventReservation reserva)
        {
            if (!_reservaService.InserirNovaReserva(reserva))
                return BadRequest();
            return CreatedAtAction(nameof(Inserir), reserva);
        }

        //PUT
        [HttpPut("/reserva/{id}/atualizar")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ServiceFilter(typeof(GaranteReservaActionFilter))]
        [Authorize(Roles = "admin")]
        public ActionResult<List<EventReservation>> Atualizar([FromRoute] long id, EventReservation reserva)
        {
            if (!_reservaService.AlterarReserva(id, reserva))
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            return NoContent();
        }

        //DELETE
        [HttpDelete("/reserva/{id}/deletar")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ServiceFilter(typeof(GaranteReservaActionFilter))]
        [Authorize(Roles = "admin")]
        public ActionResult<List<EventReservation>> Deletar([FromRoute] long id)
        {
            if (!_reservaService.DeletarReserva(id))
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            return NoContent();
        }
    }
}