using Microsoft.Extensions.Primitives;
using System.Runtime.CompilerServices;

namespace MyFirstApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            
            var app = builder.Build();

            app.Run(async (HttpContext context) =>
            {
                StreamReader reader = new StreamReader(context.Request.Body);
                var bodyReader = await reader.ReadToEndAsync();

                Dictionary<string, StringValues> dictBodyReader = Microsoft.AspNetCore.WebUtilities.QueryHelpers.ParseQuery(bodyReader);
                //if (dictBodyReader.ContainsKey("God"))
                //{
                //    var firstGod = dictBodyReader["God"][0];
                //    await context.Response.WriteAsync(firstGod);
                //}

                //Below is practice:

                if (dictBodyReader.ContainsKey("God"))
                {
                    foreach (var item in dictBodyReader["God"])
                    {
                       await context.Response.WriteAsync(item);
                       await context.Response.WriteAsync("सब ठिकठाक");
                    }
                }

            });

            app.Run();
        }
    }
}
