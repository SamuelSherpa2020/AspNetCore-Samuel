using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.FileProviders;
using System.ComponentModel.Design.Serialization;
using System.IO;


public class Program
{
    public static void Main(string[] args)
    {

        //var builder = WebApplication.CreateBuilder(args);
        var builder = WebApplication.CreateBuilder(new WebApplicationOptions()
        {
            WebRootPath = "myroot"
        });

        var app = builder.Build();

        app.UseStaticFiles(); //works the web root path (myroot)

        app.UseStaticFiles(new StaticFileOptions()
        {
            FileProvider = new PhysicalFileProvider(
              Path.Combine(builder.Environment.ContentRootPath, "mywebroot"))
        });


        app.UseRouting();

        app.UseEndpoints(endpoints =>
        {
            endpoints.Map("/", async (context) =>
            {
                await context.Response.WriteAsync("Hello");
            });
        });
        //app.MapGet("/", () => "Hello World!");
        app.Run(async context =>
        {
            await context.Response.WriteAsync("I am terminating middleware");
        });
        app.Run();

    }
}
