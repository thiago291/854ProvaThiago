using Microsoft.AspNetCore.Mvc.Filters;

namespace WebAPI_2608.Filters
{
    public class LogResultFilter : IResultFilter
    {
        public void OnResultExecuted(ResultExecutedContext context)
        {
            Console.WriteLine("Filtro de Resource LogResourceFilter (APÓS) OnResultExecuted");
        }

        public void OnResultExecuting(ResultExecutingContext context)
        {
            //context.HttpContext.Request.Headers
            Console.WriteLine("Filtro de Resource LogResourceFilter (ANTES) OnResultExecuting");
        }
    }
}
