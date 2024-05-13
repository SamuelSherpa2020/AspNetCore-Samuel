using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using System.Threading.Tasks;

namespace Assignment6.CustomMiddlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class MyEmailPasswordMiddleware
    {
        private readonly RequestDelegate _next;

        public MyEmailPasswordMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            if (context.Request.Path.Equals("/") && context.Request.Method.Equals("POST"))
            {
                //let us read response body as a stream
                StreamReader reader = new StreamReader(context.Request.Body);
                string body = await reader.ReadToEndAsync();

                //let us put the key and values received from the body in dictionary
                Dictionary<string, StringValues> queryDict = Microsoft.AspNetCore.WebUtilities.QueryHelpers.ParseQuery(body);
                string? email = null, password = null;

                string validEmail = "admin@example.com";
                string validPassword = "admin1234";
                //if (queryDict.ContainsKey("email"))
                //{
                //}
                if (queryDict.ContainsKey("email"))
                {
                    email = queryDict["email"][0];
                }
                else
                {
                    context.Response.StatusCode = 400;
                    await context.Response.WriteAsync("Invalid input for 'email'\n");
                }

                if (queryDict.ContainsKey("password"))
                {
                    password = queryDict["password"][0];
                }
                else
                {
                    context.Response.StatusCode = 400;
                    await context.Response.WriteAsync("Invalid input for 'password'\n");
                }

                if (string.IsNullOrEmpty(email).Equals(false) && string.IsNullOrEmpty(password).Equals(false))
                {
                    if (email!.Equals(validEmail) && password!.Equals(validPassword))
                    {
                        context.Response.StatusCode = 200;
                        await context.Response.WriteAsync("Successful login\n");
                    }
                }
                await _next(context);
            }
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class MyEmailPasswordMiddlewareExtensions
    {
        public static IApplicationBuilder UseMyEmailPasswordMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<MyEmailPasswordMiddleware>();
        }
    }
}
