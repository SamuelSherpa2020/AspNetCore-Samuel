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


            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("Use of First GetEndpoint()\n");
                Microsoft.AspNetCore.Http.Endpoint? endPoint = context.GetEndpoint();
                if (endPoint != null)
                {
                    await context.Response.WriteAsync($"First Endpoint name: {endPoint.DisplayName}\n\n");
                }
                await next(context);
            });


            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("Use of Second GetEndpoint()\n");
                Microsoft.AspNetCore.Http.Endpoint? endPoint = context.GetEndpoint();
                if (endPoint != null)
                {
                    await context.Response.WriteAsync($"Second Endpoint name: {endPoint.DisplayName}\n\n");
                }

                await next(context);
            });


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("Map1", async (context) =>
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
