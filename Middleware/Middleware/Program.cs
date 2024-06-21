using Middleware.CustomMiddleware;


//1. Create an instance of web app builder
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<MyMiddleware>();

//2. Create an instance of WebApplication
var app = builder.Build();



//Middleware 1
app.Use(async (HttpContext context, RequestDelegate next) =>
{
    await context.Response.WriteAsync("Welcome to ASP.NET Core Project!");
    await next(context);
});

//Middleware 2
app.Use(async (HttpContext context, RequestDelegate next) =>
{
    await context.Response.WriteAsync("\n\n");
    await next(context);
});

//Middleware 3 - Using custom middleware class
//app.UseMiddleware<MyMiddleware>();
app.MyMiddleware();

//Middleware 4
app.Run(async (HttpContext context) =>
{
    await context.Response.WriteAsync("This is my new first ASP.NET Core Project!");
});




app.Run();