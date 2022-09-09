using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace WebAPI_2608.Filters
{
    public class LogTimeFilter : IActionFilter
    {
        private Stopwatch timer = new Stopwatch();
        public void OnActionExecuted(ActionExecutedContext context)
        {
            timer.Stop();
            var executionTime = timer.ElapsedMilliseconds;
            Console.WriteLine($"Tempo de execução: {timer.ElapsedMilliseconds}ms");
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            timer.Reset();
            timer.Start();
        }
    }
}
