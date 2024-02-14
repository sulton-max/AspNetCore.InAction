using System.Diagnostics;

namespace N1.CustomMiddleware.Middlewares;

public class LoggingMiddleware(ILogger<LoggingMiddleware> logger) : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        // Log the request method and path
        logger.LogInformation("Request: {Method} {Path}", context.Request.Method, context.Request.Path);

        var watch = Stopwatch.StartNew();

        // Call the next middleware in the pipeline
        await next(context);

        watch.Stop();
        var elapsedMs = watch.ElapsedMilliseconds;

        // Log the response status code and the elapsed time
        logger.LogInformation("Response: {StatusCode}, Processing time: {ElapsedMilliseconds}ms", context.Response.StatusCode, elapsedMs);
    }
}