using System.Net;

namespace BuberDinner.WebApi.Middleware
{
    public class ErrorHandlingMiddleware
    {
        public ErrorHandlingMiddleware()
        {

        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {

                await HandleExceptionAsync(context, ex);
            }
            
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var code = HttpStatusCode.InternalServerError; // 500 if unexpecting
            var result = JSonConvert.S
        }
    }
}
