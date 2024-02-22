using MiddlewareExample.CustomMiddlewareFolder;

namespace MiddlewareExample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddTransient<MyCustomMiddleware>();

            var app = builder.Build();

           

            //Middleware Chain 1
            app.Use(async(HttpContext context,RequestDelegate next)=>{
                await context.Response.WriteAsync("1st Middleware\n");
                await next(context);

            });
            //Middleware Chain 2
            app.UseSamuelConventionalMiddleware();

            //Terminating Middleware
            app.Run(async (HttpContext context) => {
                await context.Response.WriteAsync("3rd Middleware : The Terminating Middleware\n");
            });

            app.Run();
        }
    }
}
