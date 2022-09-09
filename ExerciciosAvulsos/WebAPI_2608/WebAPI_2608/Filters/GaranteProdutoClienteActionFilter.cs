using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using WebAPI_2608.Core.Interface;

namespace WebAPI_2608.Filters
{
    public class GaranteProdutoClienteActionFilter : ActionFilterAttribute
    {
        public IClienteService _clienteService;

        public GaranteProdutoClienteActionFilter(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            long id = (long)context.ActionArguments["id"];
            if (_clienteService.ConsultarClientes(id) == null)
            {
                context.Result = new StatusCodeResult(StatusCodes.Status400BadRequest);
            }
        }

    }
}
