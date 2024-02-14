using Microsoft.AspNetCore.Diagnostics;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// Use developer exception page only in development
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

// Use exception handler page in production
if (app.Environment.IsProduction())
{
    app.UseExceptionHandler("/error");

    app.MapGet(
        "/error",
        (HttpContext httpContext) =>
        {
            var exceptionHandlerPathFeature = httpContext.Features.Get<IExceptionHandlerPathFeature>();
            var exception = exceptionHandlerPathFeature?.Error;
            return Results.Problem(title: "An error occurred", detail: exception?.Message);
        }
    );
}

app.MapGet("/", () => { throw new Exception("Exception occured"); });

app.Run();