﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Data.SqlClient;

namespace WebAPI_2608.Filters
{
    public class GeneralExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            var erro500 = new ProblemDetails
            {
                Status = 500,
                Title = "Erro inesperado",
                Detail = "Erro inesperado. Tente novamente",
                Type = context.Exception.GetType().Name
            };

            var erro417 = new ProblemDetails
            {
                Status = 417,
                Title = "Erro inesperado no sistema",
                Detail = "Erro inesperado no sistema",
                Type = context.Exception.GetType().Name
            };

            var erro503 = new ProblemDetails
            {
                Status = 503,
                Title = "Serviço indisponível",
                Detail = "Serviço indisponível. Tente novamente mais tarde.",
                Type = context.Exception.GetType().Name
            };
            Console.WriteLine($"Tipo da exceção {context.Exception.GetType().Name}, mensagem {context.Exception.Message}, stack trace {context.Exception.StackTrace}");

            switch (context.Exception)
            {
                case SqlException:
                    context.HttpContext.Response.StatusCode = StatusCodes.Status503ServiceUnavailable;
                    context.Result = new ObjectResult(erro503);
                    break;
                case NullReferenceException:
                    context.HttpContext.Response.StatusCode = StatusCodes.Status417ExpectationFailed;
                    context.Result = new ObjectResult(erro417);
                    break;
                default:
                    context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
                    context.Result = new ObjectResult(erro500);
                    break;

            }
        }
    }
}
