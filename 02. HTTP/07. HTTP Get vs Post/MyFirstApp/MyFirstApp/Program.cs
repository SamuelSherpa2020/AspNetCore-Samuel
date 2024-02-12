using System.Runtime.CompilerServices;

namespace MyFirstApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            var app = builder.Build();
            app.Run(async (HttpContext context) =>
            {
                context.Response.Headers["content-type"] = "text/html";

                if (context.Request.Headers.ContainsKey("AuthorizationKey"))
                {
                    var authorizationKey = context.Request.Headers["AuthorizationKey"];
                    await context.Response.WriteAsync($"<p>The value in AuthorizationKey is: {authorizationKey}</p>");
                }

            });

            app.Run();
        }
    }
}
