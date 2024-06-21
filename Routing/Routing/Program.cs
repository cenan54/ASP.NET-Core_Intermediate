var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();


app.UseRouting();

app.UseEndpoints(endpoint =>
{
    ////Define routes
    //endpoint.Map("/Home", async (context) =>
    //{
    //    await context.Response.WriteAsync("You are in Home page!");
    //});

    //endpoint.MapGet("/Product", async (context) =>
    //{
    //    await context.Response.WriteAsync("You are in Product get page!");
    //});

    //endpoint.MapPost("/Product", async (context) =>
    //{
    //    await context.Response.WriteAsync("You are in Product post page! Post created!");
    //});

    endpoint.MapGet("/products/{id:int}", async (context) =>
    {
        var productId = context.Request.RouteValues["id"];
        if (productId != null)
        {
            productId = Convert.ToInt32(productId);
            await context.Response.WriteAsync("This is product page with ID: " + productId);
        }else
        {
            await context.Response.WriteAsync("You are in products page.");
        }
        
    });

    endpoint.MapGet("/books/{authorname}/{bookid?}", async (context) =>
    {
        var bookId = context.Request.RouteValues["id"];
        var authorname = context.Request.RouteValues["authorname"];

        if (bookId != null && authorname != null)
        {
            bookId = Convert.ToInt32(bookId);
            authorname = Convert.ToString(authorname);
            await context.Response.WriteAsync($"This is the book authored by {authorname} and book id is {bookId}");
        }
        else
        {
            await context.Response.WriteAsync($"Welcome to the books page.");
        }
        
    });

    endpoint.MapGet("/reports/{year:int:min(1999):minlength(4)}/{month:regex(^(mar|jun|sep|dec)$)}", async (context) =>
    {
        int year = Convert.ToInt32(context.Request.RouteValues["year"]);
        string month = Convert.ToString(context.Request.RouteValues["month"]);
        await context.Response.WriteAsync($"This is the quterly report for {year}-{month}");
    });

    endpoint.MapGet("/monthly-reports/{month:regex(^([1-9]|1[012])$)}", async (context) =>
    {
        int monthNumber = Convert.ToInt32(context.Request.RouteValues["month"]);
        await context.Response.WriteAsync($"This is the quterly report for {monthNumber}");
    });

    endpoint.MapGet("/daily-reports/{date:regex(^([1-9]|1[012])$)}", async (context) =>
    {
        int monthNumber = Convert.ToInt32(context.Request.RouteValues["month"]);
        await context.Response.WriteAsync($"This is the quterly report for {monthNumber}");
    });

});



app.Run( async (HttpContext context) =>
{
    await context.Response.WriteAsync("Welcome to ASP.NET Core app!");
});

app.Run();
