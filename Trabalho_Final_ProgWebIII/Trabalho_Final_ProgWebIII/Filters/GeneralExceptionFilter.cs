using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Data.SqlClient;

namespace Trabalho_Final_ProgWebIII.Filters
{
    public class GeneralExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            var erro500 = new ProblemDetails
            {
                Status = 500,
                Title = "Erro inesperado",
                Detail = "Erro inesperado. Tente novamente.",
                Type = context.Exception.GetType().Name
            };


            var erro503 = new ProblemDetails
            {
                Status = 503,
                Title = "Serviço indisponível",
                Detail = "Serviço indisponível. Tente novamente mais tarde.",
                Type = context.Exception.GetType().Name
            };

            var erro404 = new ProblemDetails
            {
                Status = 404,
                Title = "Serviço não encontrado.",
                Detail = "Serviço não encontrado. Tente novamente.",
                Type = context.Exception.GetType().Name
            };

            var erro400 = new ProblemDetails
            {
                Status = 400,
                Title = "Requisição errônea.",
                Detail = "Sua requisição contém erros. Tente novamente.",
                Type = context.Exception.GetType().Name
            };

            var erro401 = new ProblemDetails
            {
                Status = 401,
                Title = "Não autorizado.",
                Detail = "Você não está autorizado a realizar esta ação.",
                Type = context.Exception.GetType().Name
            };

            Console.WriteLine($"Tipo da exceção {context.Exception.GetType().Name}, mensagem {context.Exception.Message}, stack trace {context.Exception.StackTrace}");

            switch (context.Exception)
            {
                case SqlException:
                    context.HttpContext.Response.StatusCode = StatusCodes.Status503ServiceUnavailable;
                    context.Result = new ObjectResult(erro503);
                    break;
                case ArgumentException:
                    context.HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
                    context.Result = new ObjectResult(erro400);
                    break;
                case InvalidDataException:
                    context.HttpContext.Response.StatusCode = StatusCodes.Status404NotFound;
                    context.Result = new ObjectResult(erro404);
                    break;
                case UnauthorizedAccessException:
                    context.HttpContext.Response.StatusCode = StatusCodes.Status401Unauthorized;
                    context.Result = new ObjectResult(erro401);
                    break;
                default:
                    context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
                    context.Result = new ObjectResult(erro500);
                    break;
            }
        }
    }
}

