namespace RoutingExample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var app = builder.Build();

            //enable routing
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("Map1",async (context) =>
                {
                   await context.Response.WriteAsync("URL Map1 been called");
                });

                endpoints.MapPost("Map2", async (context) =>
                {
                    await context.Response.WriteAsync("URL Map2 been found");
                });
            });

            app.Run(async context =>
            {
                await context.Response.WriteAsync($"The program is running in {context.Request.Path} URL.");
            });

            app.Run();
        }
    }
}
