namespace MiddlewareExample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var app = builder.Build();

            //Middleware 1
            app.Use(async (HttpContext context,RequestDelegate next) =>
            {
                await context.Response.WriteAsync("hello");
                await next(context);
            });
            
            //Middleware 2
            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("Hello again");
                await next(context);
            });

            app.Run(async (HttpContext context) =>
            {
                await context.Response.WriteAsync("terminal/shortcicuit middleware is called");
            });
            app.Run();
        }
    }
}
