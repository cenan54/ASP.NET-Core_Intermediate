
namespace Middleware.CustomMiddleware
{
    public class MyMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            context.Response.WriteAsync("Custom middleware started!");
            //Before logic
            await next(context);
            //After logic
            context.Response.WriteAsync("Custom middleware finished!");
        }
    }

    public static class CustomMiddlewareExtension
    {
        public static IApplicationBuilder MyMiddleware(this IApplicationBuilder app)
        {
            return app.UseMiddleware<MyMiddleware>();
        }
    }


}
