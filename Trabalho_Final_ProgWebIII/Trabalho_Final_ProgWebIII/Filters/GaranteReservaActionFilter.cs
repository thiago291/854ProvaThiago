using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Trabalho_Final_ProgWebIII.Core.Interface;
namespace Trabalho_Final_ProgWebIII.Filters
{
    public class GaranteReservaActionFilter : ActionFilterAttribute
    {
        public IEventReservationService _reservaService;

        public GaranteReservaActionFilter(IEventReservationService reservaService)
        {
            _reservaService = reservaService;
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            long id = (long)context.ActionArguments["id"];
            if (!_reservaService.EventoTemReserva(id))
            {
                context.Result = new StatusCodeResult(StatusCodes.Status400BadRequest);
            }
        }
    }
}
