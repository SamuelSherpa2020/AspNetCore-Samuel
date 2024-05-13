using ViewExample.Controllers;

namespace ViewExample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllersWithViews();
            var app = builder.Build();

            app.UseStaticFiles();
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.Map("/", async context =>
                {
                 context.Response.Redirect("/home");
                });
            });
            app.MapControllers();

            

            app.Run();
        }
    }
}
