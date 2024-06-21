using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Primitives;



var builder = WebApplication.CreateBuilder(args);


var app = builder.Build();


//app.MapGet("/", (HttpContext context) =>
//{
//    context.Response.WriteAsync("Hello from server");
//    //string path = context.Request.Path;
//    //string method = context.Request.Method;

//    //if (path=="/" || path == "/Home")
//    //{
//    //    context.Response.StatusCode = 200;
//    //    await context.Response.WriteAsync("Þu anda anasayfadasýnýz.");
//    //}
//    //else if (path=="Contact")
//    //{
//    //    context.Response.StatusCode = 200;
//    //    await context.Response.WriteAsync("Þu anda iletiþim sayfasýndasýnýz.");
//    //}
//    //else if (path == "Product")
//    //{
//    //    context.Response.StatusCode = 200;
//    //    if (context.Request.Query.ContainsKey("id")
//    //    {

//    //    }
//    //}
//});

app.Run(async (HttpContext context) =>
{

    string path = context.Request.Path;
    string method = context.Request.Method;

    if (path == "/" || path == "/Home")
    {
        context.Response.StatusCode = 200;
        await context.Response.WriteAsync("Þu anda anasayfadasýnýz.");
    }
    else if (path == "/Contact")
    {
        context.Response.StatusCode = 200;
        await context.Response.WriteAsync("Þu anda iletiþim sayfasýndasýnýz.");
    }
    else if (method == "GET" && path == "/Product")
    {
        context.Response.StatusCode = 200;
        if (context.Request.Query.ContainsKey("id")&& context.Request.Query.ContainsKey("name"))
        {
            string id = context.Request.Query["id"];
            string name = context.Request.Query["name"];
            await context.Response.WriteAsync($"{id} id'sine sahip {name} urununu sectiniz.");
            return;
        }
        
            context.Response.StatusCode = 200;
            await context.Response.WriteAsync("Su anda urunler sayfasindasiniz.");
        
       
    }
    else if (method == "POST" && path == "/Product")
    {
        string id = "";
        string name = "";
        //Bu kod stream reader nesnesi oluþturarak gelen post requestin bodysini okur
        StreamReader reader = new StreamReader(context.Request.Body);
        string data = await reader.ReadToEndAsync();
        //Bu kod ise Dictionary nesnesi ile plain texti key value pairlerin çevirir
        Dictionary<string, StringValues> dict = QueryHelpers.ParseQuery(data);

        if (dict.ContainsKey("id"))
        {
            id = dict["id"];
        }
        if (dict.ContainsKey("name"))
        {
            name = dict["name"][0];
        }

        await context.Response.WriteAsync("Id: " + id + "\n" +"Name: " + name);
    }
    else
    {
        context.Response.StatusCode = 404;
        await context.Response.WriteAsync("Aradiginiz sayfa bulunamadi.");
    }
});

app.Run();

