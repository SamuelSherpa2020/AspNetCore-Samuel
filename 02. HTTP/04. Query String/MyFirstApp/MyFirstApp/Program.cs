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
                context.Response.Headers["content-type"] = "text/html";
                var method = context.Request.Method;

                if (method.Equals("GET"))
                {
                    if (context.Request.Query.ContainsKey("id"))
                    {
                        var id = context.Request.Query["id"];
                        await context.Response.WriteAsync($"<p>The id is: {id}</p>");
                    }
                }
            });

            app.Run();
        }
    }
}
