using Microsoft.AspNetCore.Http;

namespace UseWhenExample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var app = builder.Build();

            //First Middleware
            app.UseWhen(
                context => context.Request.Query.ContainsKey("username"),
                 app =>
                {
                    app.Use(async (context,next) =>
                    {
                        await context.Response.WriteAsync("The conditioned got fulfilled.");
                        await next(context);
                    });
                   
                }
                );

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello there");
            });

            app.Run();
        }
    }
}
