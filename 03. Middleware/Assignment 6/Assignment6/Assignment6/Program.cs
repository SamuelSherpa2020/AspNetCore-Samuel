namespace Assignment6
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var app = builder.Build();

            app.Use(async (HttpContext context, RequestDelegate next) =>
            {
                string? email = Convert.ToString(context.Request.Query["email"]);
                string? password = Convert.ToString(context.Request.Query["password"]);
                if(email is not null && password is not null)
                {
                if(email!.Equals("admin@example") && password!.Equals("admin1234"))
                {
                    context.Response.StatusCode = 200;
                    await context.Response.WriteAsync("Successful login");
                }
                }
                await next(context);
            });
            app.MapGet("/", () => "Hello World!");

            app.Run();
        }
    }
}
