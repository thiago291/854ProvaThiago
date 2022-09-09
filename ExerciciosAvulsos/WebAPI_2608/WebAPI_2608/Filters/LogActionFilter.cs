using Microsoft.AspNetCore.Mvc.Filters;

namespace WebAPI_2608.Filters
{
    public class LogActionFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            Console.WriteLine("Filtro de Resource LogResourceFilter (APÓS) OnActionExecuted");
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            //context.HttpContext.Request.Headers
            Console.WriteLine("Filtro de Resource LogResourceFilter (ANTES) OnActionExecuting");
        }
    }
}
