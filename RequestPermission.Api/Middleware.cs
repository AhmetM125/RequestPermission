using System.Diagnostics;

namespace RequestPermission.Api
{
    public class Middleware
    {
        private readonly RequestDelegate _next;

        public Middleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            string ipAddress = context.Connection.RemoteIpAddress.ToString();
            string path = context.Request.Path;
            string method = context.Request.Method;
            Debug.WriteLine($"Request from {ipAddress} to {path} using {method}");
            // Call the next middleware in the pipeline
            await _next(context);
        }

    }
    public static class SimpleMiddlewareExtensions
    {
        public static IApplicationBuilder UseMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<Middleware>();
        }
    }
}
