using System.Runtime.CompilerServices;

namespace MiddlewareExample.CustomMiddlewareFolder
{
    public class MyCustomMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            await context.Response.WriteAsync("2nd Middleware\n");
            await next(context);
            //await context.Response.WriteAsync("2nd Middleware ends.\n");
        }
    }

    public static class CustomMiddlewareExention
    {
        public static IApplicationBuilder UseMyCustomMidleware(this IApplicationBuilder samuel)
        {
            return samuel.UseMiddleware<MyCustomMiddleware>();
        }
    }
}
