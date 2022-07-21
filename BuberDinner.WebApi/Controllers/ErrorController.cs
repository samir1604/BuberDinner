using BuberDinner.Application.Common.Errors;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.WebApi.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ErrorController : ControllerBase
    {        
        [Route("/api/error")]        
        public IActionResult Error()
        {
            Exception? exception = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;

            var (statusCode, message) = exception switch
            {
                DuplicateEmailException => (StatusCodes.Status409Conflict, "Email already exists"),                
                _ => (StatusCodes.Status500InternalServerError, "An unexpected error ocurred")
            };
            
            return Problem(statusCode: statusCode, title: message);
        }
    }
}
