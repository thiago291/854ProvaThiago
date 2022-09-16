using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Trabalho_Final_ProgWebIII.Core.Interface;
namespace Trabalho_Final_ProgWebIII.Filters
{
    public class GaranteEventoActionFilter : ActionFilterAttribute
    {
        public ICityEventService _eventoService;

        public GaranteEventoActionFilter(ICityEventService eventoService)
        {
            _eventoService = eventoService;
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            long id = (long)context.ActionArguments["id"];
            if (_eventoService.ConsultarEventoPorID(id) == null)
            {
                context.Result = new StatusCodeResult(StatusCodes.Status400BadRequest);
            }
        }
    }
}
