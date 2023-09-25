using System.Net;
using System.Text.Json;
using Ecommerce.Exceptions;

namespace Ecommerce.Middlewares{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlerMiddleware(RequestDelegate next)
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

        private static Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            var code = HttpStatusCode.InternalServerError;

            if (ex is OrderMissingProductException) code = HttpStatusCode.BadRequest;
            else if (ex is OrderMissingOrderDetailsException) code = HttpStatusCode.BadRequest;
            else if (ex is ArgumentNullException) code = HttpStatusCode.BadRequest;

            var result = JsonSerializer.Serialize(new { error = ex.Message });
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;

            return context.Response.WriteAsync(result);
        }
    }
}
