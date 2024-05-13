using ControllersExample.Controllers;

namespace ControllersExample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllers(); // also can be written as: builder.Services.AddTransient<HomeController
            //builder.Services
            var app = builder.Build();
            //app.Use((HttpContext context, RequestDelegate next) =>
            //{
            //    return next(context);
            //});
            //app.UseRouting();
            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.Map("/", async context =>
            //    {
            //        await context.Response.WriteAsync("Hello World !");
            //    });

            //    //endpoints.Map("Home/AboutUs", async (context) =>
            //    //{
            //    //    await context.Response.WriteAsync("Hello from about us");
            //    //});
            //});
            app.UseStaticFiles();
            app.MapControllers();
            //app.MapControllers();
            //app.MapGet("/", () => "Hello World!");

            app.Run();
        }
    }
}
