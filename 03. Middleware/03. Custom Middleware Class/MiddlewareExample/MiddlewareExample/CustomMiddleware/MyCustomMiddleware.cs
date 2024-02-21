using System.Runtime.CompilerServices;

namespace MiddlewareExample.CustomMiddleware
{
    public class MyCustomMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            await Task.Delay(10000);
            await context.Response.WriteAsync("2nd Middleware Starts\n");

            await Task.Delay(1000);
            //return next(context);
            await Task.Delay(1000);

            await context.Response.WriteAsync("2nd Middleware ends.\n");
        }
    }
}
