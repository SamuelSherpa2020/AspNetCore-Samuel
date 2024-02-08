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
                if (1 != 1)
                {
                    context.Response.StatusCode = 200;
                }
                else
                {
                    context.Response.StatusCode = 401;
                    //context.Response.StatusCode = 200;
                }
                await context.Response.WriteAsync("Hello");
                await context.Response.WriteAsync("World !");


                /*instead of using async, we can also write the following code to remove async and await which also work fine.
                return Task.CompletedTask;
                */
            });


        }
    }
}
