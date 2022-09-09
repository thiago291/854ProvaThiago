using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using WebAPI_2608.Core.Interface;
using WebAPI_2608.Core.Model;

namespace WebAPI_2608.Filters
{
    public class CPFNaoEstaDuplicadoActionFilter : ActionFilterAttribute
    {
        public IClienteService _clienteService;

        public CPFNaoEstaDuplicadoActionFilter(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            Cliente cliente = (Cliente)context.ActionArguments["cliente"];
            if (_clienteService.ConsultarClientes(cliente.CPF) != null)
            {
                context.Result = new StatusCodeResult(StatusCodes.Status409Conflict);
            }
        }
    }
}
