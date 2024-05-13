namespace RoutingExample
{
    public class Program
    {
        private static string? churchName;
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
                endpoints.MapGet("ChurchName/{CornerStone}", async (context) =>
                {
                    churchName = Convert.ToString(context.Request.RouteValues["cornerstone"]);
                    await context.Response.WriteAsync($"The name of the church is: {churchName}");
                });

                endpoints.MapPost("ShepherdNames/{pastorName}&{eldername}", async (context) =>
                {
                    var pastorName = Convert.ToString(context.Request.RouteValues["pastorname"]);
                    var elderName = Convert.ToString(context.Request.RouteValues["eldername"]);
                    
                    await context.Response.WriteAsync($"The shepherdnames of : {churchName} church are {pastorName}, {elderName} has been called.");
                });
            });

            #endregion

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync($"We are in the path: {context.Request.Path}");
            });

            app.Run();
        }
    }
}
