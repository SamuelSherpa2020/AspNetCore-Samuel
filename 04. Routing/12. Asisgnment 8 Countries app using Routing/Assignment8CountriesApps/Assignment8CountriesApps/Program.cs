var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

Dictionary<int, string> countries = new Dictionary<int, string>();
countries.Add(1, "United States");
countries.Add(2, "Canada");
countries.Add(3, "United Kingdom");
countries.Add(4, "India");
countries.Add(5, "Japan");

app.UseRouting();
app.UseEndpoints(endpoints =>
{
    // Example 1
    //endpoints.MapGet("countries", async context =>
    //{
    //    context.Response.StatusCode = 200;
    //    foreach (var item in countries)
    //    {
    //        await context.Response.WriteAsync($"{item.Key}, {item.Value}\n");
    //    }
    //});

    // Example 2

    //endpoints.MapGet("countries/{id:int=5}", async context =>
    //{
    //    context.Response.StatusCode = 200;
    //    int countryId = Convert.ToInt32(context.Request.RouteValues["id"]);
    //    var countryName = countries[countryId];
    //    await context.Response.WriteAsync($"{countryName}");

    //});

    //Example 3

    //endpoints.MapGet("countries/{id:range(1,5)}", async (context) =>
    //{

    //    int countryId = Convert.ToInt32(context.Request.RouteValues["id"]);
    //    if (countryId <= 5)
    //    {
    //        string? countryName = countries[countryId];
    //        await context.Response.WriteAsync($"{countryName}");
    //    }
    //    else
    //    {
    //        context.Response.StatusCode = 404;
    //        await context.Response.WriteAsync("[[No Country]]");
    //    }

    //});

    //Example 4

    endpoints.MapGet("countries/{id:int}", async (context) =>
    {
        int? idValue = Convert.ToInt32(context.Request.RouteValues["id"]);
        if (idValue < 100)
        {
            await context.Response.WriteAsync($"{idValue}");
        }
        else
        {
            await context.Response.WriteAsync("The countryId should be between 1 and 100");
        }


    });


    endpoints.MapGet("/", async context =>
    {
        await context.Response.WriteAsync("Hello World");
    });

});


app.Run(async context =>
{
    await context.Response.WriteAsync("No Country");

});

app.Run();
