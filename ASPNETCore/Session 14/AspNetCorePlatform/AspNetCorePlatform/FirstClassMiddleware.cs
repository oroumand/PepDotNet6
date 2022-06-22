namespace AspNetCorePlatform;

public class FirstClassMiddleware
{
    private readonly RequestDelegate _next;

    public FirstClassMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        if (context.Request.Query.ContainsKey("AddText"))
        {
            await context.Response.WriteAsync("First Class Executing. \n");
        }
        await _next(context);
        if (context.Request.Query.ContainsKey("AddText"))
        {
            await context.Response.WriteAsync("First Class Executed. \n");
        }

    }

}


public class SeccondClassMiddleware
{
    private readonly RequestDelegate _next;

    public SeccondClassMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        //context.Response.ContentType = "text/html";

        int A = 123;
        //await context.Response.WriteAsync("Seccond Class Executing. \n");

        await _next(context);
        int B = 12;

        //await context.Response.WriteAsync("Seccond Class Executed. \n");


    }

}


public class ThirdClassMiddleware
{
    private readonly RequestDelegate _next;

    public ThirdClassMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {

        //await context.Response.WriteAsync("Third Class Executing. \n");
        int A = 123;

        await _next(context);
        int B = 12;

        //await context.Response.WriteAsync("Third Class Executed. \n");


    }

}