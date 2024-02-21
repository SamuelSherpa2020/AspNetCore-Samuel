namespace MiddlewareExample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var app = builder.Build();

           

            //Middleware Chain 1
            app.Use(async(HttpContext context,RequestDelegate next)=>{
                await context.Response.WriteAsync("1st Middleware\n");
                await next(context);
            });

            //Middleware Chain 2
            app.Use(async (HttpContext context, RequestDelegate next) => {
                await context.Response.WriteAsync("2nd Middleware\n");
                await next(context);
            });

            //Middleware Chain 2
            app.Use(async (HttpContext context, RequestDelegate next) => {
                await context.Response.WriteAsync("3rd Middleware\n");
                await next(context);
            });
            app.Run(async (HttpContext context) => {
                await context.Response.WriteAsync("Terminating Middleware");
            });

            app.Run();
        }
    }
}
