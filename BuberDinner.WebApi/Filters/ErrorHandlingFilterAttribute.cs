using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace BuberDinner.WebApi.Filters
{
    public class ErrorHandlingFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            var exception = context.Exception;

            var problemDetails = new ProblemDetails
            { 
                Type = "https://tools.ietf.org/html/rfc7231#section-6.6.1",
                Instance = context.HttpContext.Request.Path,
                Status = (int)HttpStatusCode.InternalServerError,
                Detail = exception.Message,
                Title = "An error ocurred while processing your request.",
            };


            context.Result = new ObjectResult(problemDetails);

            context.ExceptionHandled = true;
        }
    }
}
