using RoutingExample.CustomConstraint;
using System.Runtime.InteropServices;

namespace RoutingExample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddRouting(options =>
            {
                options.ConstraintMap.Add("months", typeof(MonthsCustomConstraint));
            });

            var app = builder.Build();

            //enable routing
            app.UseRouting();


            app.UseEndpoints(endpoints =>
            {
                endpoints.Map("files/{fileName=aspnetcoreSamuel}&{extension=dot}", async (context) =>
                {
                    string? fileName = Convert.ToString(context.Request.RouteValues["fileName"]);
                    string? extension = Convert.ToString(context.Request.RouteValues["extension"]);

                    await context.Response.WriteAsync($"The file name is: {fileName}.{extension}");
                });

                endpoints.Map("employee/profile/{employeeName:length(4,7):alpha=samuel}", async (context) =>
                {
                    if (context.Request.RouteValues.ContainsKey("employeename"))
                    {
                        string? employeeName = Convert.ToString(context.Request.RouteValues["employeeName"]);
                        await context.Response.WriteAsync($"Employee Name is: {employeeName}");
                    }
                    else
                    {
                        await context.Response.WriteAsync("The employee name is not given so no default value is written.");
                    }
                });

                endpoints.Map("products/detail/{id:int=777}", async (context) =>
                {
                    if (context.Request.RouteValues.ContainsKey("id"))
                    {
                        int productId = Convert.ToInt32(context.Request.RouteValues["id"]);
                        await context.Response.WriteAsync($"The id of the product is: {productId}\n\n");

                        //int queryValue = Convert.ToInt32(context.Request.Query["1"]);
                        //await context.Response.WriteAsync($"The employeeid using query is value {queryValue}\n");
                    }
                    else
                    {
                        await context.Response.WriteAsync("The product id was not supplied");
                    }
                });

                endpoints.Map("daily-digest/{reportdate:datetime}", async (context) =>
                {
                    if (context.Request.RouteValues.ContainsKey("reportdate"))
                    {
                        DateTime reportDate = Convert.ToDateTime(context.Request.RouteValues["reportdate"]);
                        await context.Response.WriteAsync($"The date of the reportdate is: {reportDate.ToShortDateString()}");
                    }
                    else
                    {
                        await context.Response.WriteAsync("The daily digest doesn't have any date");
                    }
                });

                endpoints.Map("friends/name/{suman:int}", async (context) =>
                {
                    if (context.Request.RouteValues.ContainsKey("suman"))
                    {
                        string? friendName = Convert.ToString(context.Request.RouteValues["suman"]);
                        await context.Response.WriteAsync($"Your friend {friendName} has been called");
                    }
                    else
                    {
                        await context.Response.WriteAsync("Suman is not called");
                    }
                });


                //for the part 2 of routing constraint

                endpoints.Map("cities/{cityid:guid}", async (context) =>
                {
                    if (context.Request.RouteValues.ContainsKey("cityid"))
                    {
                        Guid cityId = Guid.Parse(Convert.ToString(context.Request.RouteValues["cityid"])!);
                        await context.Response.WriteAsync($"The cityid is: {cityId}");
                    }
                    else
                    {
                        await context.Response.WriteAsync("The city is not given guid id");
                    }
                });

                endpoints.Map("stats-report/{year:int:range(1990,2000)}/{month:months}", async (context) =>
                {
                    int year = Convert.ToInt32(context.Request.RouteValues["year"]);
                    string? month = Convert.ToString(context.Request.RouteValues["month"]);

                    if (month == "jan" || month == "feb" || month == "march" || month == "april")
                    {
                        await context.Response.WriteAsync($"Year: {year} and month {month}\n");
                    }
                    else
                    {
                        await context.Response.WriteAsync($"Month {month} didn't match so no stats-report\n");
                    }

                    if (context.Request.RouteValues.ContainsKey("year") && context.Request.RouteValues.ContainsKey("month"))
                    {
                        await context.Response.WriteAsync($"Both Year and month is present in the url\n");
                    }
                });

                endpoints.Map("countries/{id:range(1,100)}", async (context) =>
                {
                    if (context.Request.RouteValues.ContainsKey("id"))
                    {
                        string? idValue = Convert.ToString(context.Request.RouteValues["id"]);
                        await context.Response.WriteAsync($"{idValue}");
                    }
                    else
                    {
                        await context.Response.WriteAsync("The countryId should be 1 and 100");

                    }
                });
            });



            app.Run(async context =>
            {
                await context.Response.WriteAsync($"The program is running in {context.Request.Path} URL.");
            });

            app.Run();
        }
    }
}
