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
                endpoints.Map("files/{fileName=aspnetcoreSamuel}&{extension=dot}", async (context) =>
                {
                    string? fileName = Convert.ToString(context.Request.RouteValues["fileName"]);
                    string? extension = Convert.ToString(context.Request.RouteValues["extension"]);

                    await context.Response.WriteAsync($"The file name is: {fileName}.{extension}");
                });

                endpoints.Map("employee/profile/{employeeName=Samuel}", async (context) =>
                {
                    string? employeeName = Convert.ToString(context.Request.RouteValues["employeeName"]);
                    await context.Response.WriteAsync($"Employee Name is: {employeeName}");
                });

                endpoints.Map("products/detail/{id:int}", async (context) =>
                {
                    if (context.Request.RouteValues.ContainsKey("id"))
                    {
                        int productId = Convert.ToInt32(context.Request.RouteValues["id"]);
                        await context.Response.WriteAsync($"The id of the product is: {productId}\n\n");

                        //int queryValue = Convert.ToInt32(context.Request.Query["1"]);
                        //await context.Response.WriteAsync($"The employeeid using query is value {queryValue}\n");

                    }
                    else
                    {
                        await context.Response.WriteAsync("The product id was not supplied");
                    }
                });

                endpoints.Map("daily-digest/{reportdate:datetime}", async (context) =>
                {
                    if (context.Request.RouteValues.ContainsKey("daily-digest"))
                    {
                        DateTime reportDate = Convert.ToDateTime(context.Request.RouteValues["reportdate"]);
                        await context.Response.WriteAsync($"The date of the reportdate is: {reportDate.ToShortDateString()}");
                    }
                    else
                    {
                        await context.Response.WriteAsync("The daily digest doesn't have any date");
                    }
                });

                endpoints.Map("friends/name/{suman:int}", async (context) =>
                {
                    if (context.Request.RouteValues.ContainsKey("suman"))
                    {
                        string? friendName = Convert.ToString(context.Request.RouteValues["suman"]);
                        await context.Response.WriteAsync($"Your friend {friendName} has been called");
                    }
                    else
                    {
                        await context.Response.WriteAsync("Suman is not called");
                    }
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
