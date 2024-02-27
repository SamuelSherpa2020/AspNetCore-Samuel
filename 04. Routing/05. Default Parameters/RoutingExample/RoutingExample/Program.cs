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
                endpoints.Map("files/{fileName}.{extension}", async (context) =>
                {
                    string? fileName = Convert.ToString(context.Request.RouteValues["fileName"]);
                    string? extension = Convert.ToString(context.Request.RouteValues["extension"]);

                    await context.Response.WriteAsync($"The file name is: {fileName} - {extension}");
                });

                endpoints.Map("employee/profile/{employeeName}", async (context) =>
                {
                    string? employeeName = Convert.ToString(context.Request.RouteValues["employeeName"]);
                    await context.Response.WriteAsync($"Employee Name is: {employeeName}");
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
