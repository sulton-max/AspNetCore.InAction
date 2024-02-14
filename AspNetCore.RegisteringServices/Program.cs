using AspNetCore.RegisteringServices.Models.Accounts;
using AspNetCore.RegisteringServices.Models.Configurations;
using AspNetCore.RegisteringServices.Services.Accounts;
using AspNetCore.RegisteringServices.Services.Notifications;

var builder = WebApplication.CreateBuilder(args);

var emailSenderSettings = new EmailSenderSettings
{
    SenderEmailAddress = "test@gmai.com"
};

var smtpServerSettings = new SmtpServerSettings
{
    Host = "smtp.gmail.com",
    Port = 587,
    EmailAddress = "test@gmail.com",
    Password = "testpass"
};

builder.Services.AddSingleton(emailSenderSettings).AddSingleton(smtpServerSettings);

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

app.MapPost("/account", async (User user, IAccountService accountService) => Results.Ok(await accountService.RegisterUser(user)));

app.Run();