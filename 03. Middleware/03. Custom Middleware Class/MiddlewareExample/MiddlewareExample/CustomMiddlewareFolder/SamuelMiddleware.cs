using System.Runtime.CompilerServices;

namespace MiddlewareExample.CustomMiddlewareFolder
{
    public class SamuelMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            await context.Response.WriteAsync("Samuel Middleware started Edited\n");
            await next(context);
            await context.Response.WriteAsync("Samuel Middleware Ends\n");
        }

      
    }

    static class SamuelMiddlewareExtension
    {
        public static IApplicationBuilder UseSamuelMiddleWare(this IApplicationBuilder app)
        {
            return app.UseMiddleware<SamuelMiddleware>();
        }
    } 
}
