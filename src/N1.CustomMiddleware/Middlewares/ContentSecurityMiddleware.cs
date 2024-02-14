namespace N1.CustomMiddleware.Middlewares;

public class ContentSecurityMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        // Adding Content-Security-Policy header to the response
        context.Response.Headers.Append("Content-Security-Policy", "default-src 'self'; script-src 'self'; object-src 'none';");
        
        await next(context);
    }
}