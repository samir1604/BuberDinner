using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;

namespace BuberDinner.WebApi.Middleware
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
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
            var problemDetail = new ProblemDetails
            {                
                Instance = context.Request.Path,
                Status = (int)HttpStatusCode.InternalServerError,
                Detail = exception.Message,
                Title = "An error ocurred while processing your request",                
            };

            var code = HttpStatusCode.InternalServerError; // 500 if unexpecting
            var result = JsonConvert.SerializeObject(problemDetail);            
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;
            return context.Response.WriteAsync(result);
        }
    }
}
