namespace MiddlewareExample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var app = builder.Build();

            app.Run(async(HttpContext context) =>
            {
                await context.Response.WriteAsync("Hello");
            });

            app.Run(async (HttpContext context) =>
            {
                await context.Response.WriteAsync("Hello");
            });

            app.Run();
        }
    }
}
