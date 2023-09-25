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

        private static readonly Dictionary<Type, HttpStatusCode> _exceptionToStatusCode = new Dictionary<Type, HttpStatusCode>
        {
            { typeof(OrderMissingProductException), HttpStatusCode.BadRequest },
            { typeof(OrderMissingOrderDetailsException), HttpStatusCode.BadRequest },
            { typeof(ArgumentNullException), HttpStatusCode.BadRequest },
            { typeof(ProductsByCategorySlugNotFound), HttpStatusCode.NotFound },
            { typeof(ProductNotFoundException), HttpStatusCode.NotFound },
            { typeof(ApplicationException), HttpStatusCode.BadRequest }
        };

        private static Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            var code = HttpStatusCode.InternalServerError;

            if (_exceptionToStatusCode.TryGetValue(ex.GetType(), out var statusCode))
            {
                code = statusCode;
            }

            var result = JsonSerializer.Serialize(new { error = ex.Message });
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;

            return context.Response.WriteAsync(result);
        }

    }
}
