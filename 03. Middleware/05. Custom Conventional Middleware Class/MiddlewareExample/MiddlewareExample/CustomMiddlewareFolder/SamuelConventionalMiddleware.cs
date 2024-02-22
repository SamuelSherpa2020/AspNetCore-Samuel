using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace MiddlewareExample.CustomMiddlewareFolder
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class SamuelConventionalMiddleware
    {
        private readonly RequestDelegate _next;

        public SamuelConventionalMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            await httpContext.Response.WriteAsync("2nd Middleware\n");

            if (httpContext.Request.Query.ContainsKey("firstName")&& httpContext.Request.Query.ContainsKey("lastName"))
            {
                var fullName = httpContext.Request.Query["firstName"] + " " +
                    httpContext.Request.Query["lastName"];

                await httpContext.Response.WriteAsync($"The Fullname of the queryString is: {fullName}\n");
            }

            await _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class SamuelConventionalMiddlewareExtensions
    {
        public static IApplicationBuilder UseSamuelConventionalMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<SamuelConventionalMiddleware>();
        }
    }
}
