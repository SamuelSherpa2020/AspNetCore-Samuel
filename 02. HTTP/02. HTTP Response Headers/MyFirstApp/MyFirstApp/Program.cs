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
                context.Response.Headers["Content-Type"] = "text/html";
                context.Response.Headers["Content-Length"] = "100";

                context.Response.StatusCode = 200;
                await context.Response.WriteAsync("<h1>Hello</h1>");
                await context.Response.WriteAsync("<p>World !</p>");


                /*instead of using async, we can also write the following code to remove async and await which also work fine.
                return Task.CompletedTask;
                if you are not using above return then you have to have app.Rune(); below:
                */
            });

            app.Run();
        }
    }
}
