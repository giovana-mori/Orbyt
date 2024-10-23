using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.VisualBasic;

namespace Pi3.Filter
{
    public class ApiExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            var exception = context.Exception;
            var message = exception.Message;
            var exceptionType = exception.GetType().Name;

            var problemDetails = new ProblemDetails()
            {
                Status = StatusCodes.Status500InternalServerError,
                Title = "Erro Interno do Servidor",
                Type = exceptionType,
                Detail = message,
                Instance = context.HttpContext.Request.Path
            };
            context.Result = new ObjectResult(problemDetails)
            {
                StatusCode = StatusCodes.Status500InternalServerError,
            };

        }
    }
}
