namespace MiddlewareExample.CustomMiddleware
{
    public class MyCustomMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            await context.Response.WriteAsync("2nd Middleware Starts\n");
            await next(context);
            await context.Response.WriteAsync("2nd Middleware ends.\n");
        }
    }
}
