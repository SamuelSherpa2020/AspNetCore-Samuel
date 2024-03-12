using Assignment6.CustomMiddlewares;
using Microsoft.Extensions.FileSystemGlobbing.Internal.PatternContexts;

namespace Assignment6
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            //builder.Services.AddTransient<MyEmailPasswordMiddleware>();

            var app = builder.Build();

            app.UseMyEmailPasswordMiddleware();

            app.Run(async context =>
            {
                await context.Response.WriteAsync("No response");
            });

            app.Run();
        }
    }
}
