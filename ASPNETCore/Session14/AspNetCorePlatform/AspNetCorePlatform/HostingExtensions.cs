using System.Net;

namespace AspNetCorePlatform;

public static class HostingExtensions
{
    public static WebApplication ConfigureServices(this WebApplicationBuilder builder)
    {
       
        return builder.Build();
    }
    public static WebApplication ConfigurePipeline(this WebApplication app)
    {
        app.Map("/admin", myapp =>
        {
            myapp.UseMiddleware<SeccondClassMiddleware>();
            myapp.UseMiddleware<ThirdClassMiddleware>();

        });

        app.Use(async(httpcontext, next) =>
        {
            if(httpcontext.Request.Query.ContainsKey("AddText"))
            {
                httpcontext.Response.ContentType = "text/html";
                await httpcontext.Response.WriteAsync("Use Middleware executing \n");
            }
            if(!httpcontext.Request.Query.ContainsKey("Sh"))
            {
                await next();

            }
            if (httpcontext.Request.Query.ContainsKey("AddText"))
            {
                await httpcontext.Response.WriteAsync("Use Middleware executed ");
            }
        });

        
        app.UseMiddleware<FirstClassMiddleware>();


        app.MapGet("/", () => "Hello World!\n");

        return app;
    }
}
