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

                if (context.Request.Headers.ContainsKey("user-agent"))
                {
                    var userAgentValue = context.Request.Headers["user-agent"];
                    await context.Response.WriteAsync($"<p>The value in key User-Agent is: {userAgentValue}</p>");
                }

                //below is my practice:
                if ((context.Request.Headers.ContainsKey("accept")) && (context.Request.Headers.ContainsKey("accept-language")))
                {
                    var accept = context.Request.Headers["accept"];
                    await context.Response.WriteAsync($"<p>The value in key Accept is: {accept}</p>");

                    var acceptLanguage = context.Request.Headers["accept-language"];
                    await context.Response.WriteAsync($"<p>The value in key Accept-Language is: {acceptLanguage}</p>");

                }

            });

            app.Run();
        }
    }
}
