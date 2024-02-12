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
                string path = context.Request.Path;
                string method = context.Request.Method;

                context.Response.Headers["content-type"] = "text/html";
                await context.Response.WriteAsync($"<p>The path is: {path}</p>");
                await context.Response.WriteAsync($"<p>The method is: {method}</p>");

                if (path.Equals("/helloSamuel"))
                {
                    await context.Response.WriteAsync($"<p>The path equals to {path}</p>");
                }
                else
                {
                    await context.Response.WriteAsync($"<p>The path IS NOT EQUAL to {path}</p>");
                }

                if (method.Equals("GET"))
                {
                    await context.Response.WriteAsync($"<p>The method equals to {method}</p>");
                }
                else
                {
                    await context.Response.WriteAsync($"<p>The method IS NOT EQUAL to {method}</p>");
                }
            });

            app.Run();
        }
    }
}
