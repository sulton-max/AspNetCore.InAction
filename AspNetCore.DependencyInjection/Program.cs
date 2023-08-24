using AspNetCore.DependencyInjection.Models.Accounts;
using AspNetCore.DependencyInjection.Models.Configurations;
using AspNetCore.DependencyInjection.Services.Accounts;
using AspNetCore.DependencyInjection.Services.Emails;

var builder = WebApplication.CreateBuilder(args);

var emailSenderSettings = new EmailSenderSettings
{
    SenderEmailAddress = "test@gmai.com"
};

var smtpServerSettings = new SmtpServerSettings
{
    Host = "smtp.gmail.com",
    Port = 587,
    EmailAddress = "test@gmai.com",
    Password = "testpass"
};

builder.Services.AddSingleton(emailSenderSettings);
builder.Services.AddSingleton(smtpServerSettings);

builder.Services.AddSingleton<IEmailSenderService, EmailSenderService>().AddScoped<IAccountService, AccountService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapPost("/account", async (User user, IAccountService accountService) => Results.Ok(await accountService.RegisterUser(user)));

app.Run();