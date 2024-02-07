
var builder = WebApplication.CreateBuilder(args);

// Other configurations...

//builder.WebHost.UseKestrel();
//builder.Services.AddControllers();

var app = builder.Build();

// Configure endpoints and middleware...


app.Run(async (HttpContext context)=>
{

    context.Response.StatusCode = 200;
    context.Response.Headers["Server"] = "My Server";
    context.Response.Headers["Context-Length"] = "100";
    context.Response.ContentType = "text/html";
    await context.Response.WriteAsync("<p>I love</p>");
    await context.Response.WriteAsync("<h1>Coding</h1>");
    //context.Response.ContentLength = 1000;
    //context.Response.ContentLength = 80;
});

app.Run();