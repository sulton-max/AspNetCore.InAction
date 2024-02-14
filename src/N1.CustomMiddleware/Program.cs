using N1.CustomMiddleware.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<LoggingMiddleware>();
builder.Services.AddTransient<RequestCorrelationMiddleware>();
builder.Services.AddTransient<ContentSecurityMiddleware>();
builder.Services.AddTransient<CustomAuthMiddleware>();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

// Middleware that neither modifies request nor response
app.UseMiddleware<LoggingMiddleware>();

// Middleware that modifies request
app.UseMiddleware<RequestCorrelationMiddleware>();

// Middleware that modifies response
app.UseMiddleware<ContentSecurityMiddleware>();

// Middleware that short-circuits the pipeline
app.UseMiddleware<CustomAuthMiddleware>();

app.Run();