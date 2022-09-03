using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Hosting;
using System.Data.Entity.Infrastructure;

namespace MirrorLink.Api.Filters
{
    public class CustomExceptionFilterAttribute : ExceptionFilterAttribute
    {
        private readonly IWebHostEnvironment _hostEnvironment;

        public CustomExceptionFilterAttribute(IWebHostEnvironment hostEnvironment)
        {
            _hostEnvironment = hostEnvironment;
        }

        public override void OnException(ExceptionContext context)
        {
            var ex = context.Exception;
            string stackTrace = _hostEnvironment.IsDevelopment() ? context.Exception.StackTrace : string.Empty;

            string message = ex.Message;
            string error;
            IActionResult actionResult;
            switch (ex)
            {
                case DbUpdateConcurrencyException ce:
                    error = "Concurrency Issue. HTTP 400";
                    actionResult = new BadRequestObjectResult(new { Error = error, Message = message, StackTrace = stackTrace })
                    {
                        StatusCode = 500
                    };
                    break;

                default:
                    error = "General error";
                    actionResult = new ObjectResult(new { Error = error, Message = message, StackTrace = stackTrace })
                    {
                        StatusCode = 500
                    };
                    break;
            }
            //context.ExceptionHandled = true; это позволяет поглощать исключение

            context.Result = actionResult;
        }
    }
}
