using Microsoft.AspNetCore.Authentication;
using System.ComponentModel.Design.Serialization;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();


app.UseStaticFiles();

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.Map("/", async (context) =>
    {
        await context.Response.WriteAsync("Hello");
    });
});
//app.MapGet("/", () => "Hello World!");

app.Run();
