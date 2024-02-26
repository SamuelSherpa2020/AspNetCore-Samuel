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
                Endpoint? endPoint = context.GetEndpoint();
                if(endPoint != null)
                {
                    await context.Response.WriteAsync($"Endpoint path: {endPoint.DisplayName} \n");
                }
                await next(context);
            });

            #region Use of UseEndpoints

            // The below is also a way of 
            //app.MapGet("/Map1", async (context) =>
            //{
            //    await context.Response.WriteAsync("I am first Map");
            //});

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/Map1", async (context) =>
                {
                    await context.Response.WriteAsync($"Endpoint: {context.Request.Path} has been called.");
                });

                endpoints.MapPost("/Map2", async (context) =>
                {
                    await context.Response.WriteAsync($"Endpoint: {context.Request.Path} has been called.");
                });
            });

            #endregion

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("I am terminating middleware");
            });

            app.Run();
        }
    }
}
