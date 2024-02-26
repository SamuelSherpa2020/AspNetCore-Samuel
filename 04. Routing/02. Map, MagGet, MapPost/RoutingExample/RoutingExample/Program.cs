namespace RoutingExample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var app = builder.Build();

            //enable routing
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                //add your endpoints
            });

            app.Run();
        }
    }
}
