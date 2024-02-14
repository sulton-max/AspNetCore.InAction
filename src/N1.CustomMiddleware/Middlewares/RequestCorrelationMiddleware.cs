namespace N1.CustomMiddleware.Middlewares;

public class RequestCorrelationMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        // Check if the request has a correlation ID, if not, add one
        if (!context.Request.Headers.ContainsKey("X-Correlation-ID"))
        {
            context.Request.Headers.Append("X-Correlation-ID", Guid.NewGuid().ToString());
        }

        await next(context);
    }
}