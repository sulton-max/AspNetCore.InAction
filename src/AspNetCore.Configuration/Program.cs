using AspNetCore.Configuration.Models.Accounts;
using AspNetCore.Configuration.Models.Configurations;
using AspNetCore.Configuration.Services.Accounts;
using AspNetCore.Configuration.Services.Notifications;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Registering strongly typed configuration
builder.Services
    .Configure<EmailSenderSettings>(builder.Configuration.GetSection(nameof(EmailSenderSettings)))
    .Configure<SmtpServerSettings>(builder.Configuration.GetSection(nameof(SmtpServerSettings)));

// Registering settings instance as singleton
builder.Services
    .AddSingleton(provider => provider.GetRequiredService<IOptions<EmailSenderSettings>>().Value)
    .AddSingleton(provider => provider.GetRequiredService<IOptions<SmtpServerSettings>>().Value);

// Registering services
builder.Services
    .AddScoped<INotificationsService, EmailNotificationsService>()
    .AddScoped<INotificationsService, SmsNotificationService>()
    .AddScoped<INotificationsService, FacebookNotificationService>();

builder.Services.AddScoped<IAccountService, AccountService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapPost("/account",
    async (User user, IAccountService accountService) => Results.Ok(await accountService.RegisterUser(user)));

app.Run();