namespace N1.CustomMiddleware.Middlewares;

public class CustomAuthMiddleware : IMiddleware
{
    public Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        if (context.User.Identity is { IsAuthenticated: true })
        {
            return next(context);
        }

        context.Response.StatusCode = 401;
        return context.Response.WriteAsync("Unauthorized");
    }
}