using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Trabalho_Final_ProgWebIII.Core.Interface;
using Trabalho_Final_ProgWebIII.Core.Model;

namespace Trabalho_Final_ProgWebIII.Filters
{
    public class GaranteEventoReservaActionFilter : ActionFilterAttribute
    {
        public ICityEventService _eventoService;

        public GaranteEventoReservaActionFilter(ICityEventService eventoService)
        {
            _eventoService = eventoService;
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            EventReservation er = (EventReservation)context.ActionArguments["reserva"];
            if (!_eventoService.ConsultarEventoPorID(er.IdEvent))
            {
                context.Result = new StatusCodeResult(StatusCodes.Status400BadRequest);
            }
        }
    }
}
