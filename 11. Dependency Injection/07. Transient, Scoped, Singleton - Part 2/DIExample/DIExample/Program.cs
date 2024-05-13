using Microsoft.AspNetCore.Mvc.Formatters;
using ServiceContractor;
using Services;

namespace DIExample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllersWithViews();
            builder.Services.Add(new ServiceDescriptor(typeof(ICitiesServices), typeof(CitiesServices),ServiceLifetime.Singleton));


            var app = builder.Build();

            app.UseStaticFiles();
            app.UseRouting();
            app.MapControllers();

            app.Run();
        }
    }
}
