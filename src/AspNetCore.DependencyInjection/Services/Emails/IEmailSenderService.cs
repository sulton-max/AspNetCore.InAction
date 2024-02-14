using AspNetCore.DependencyInjection.Models.Emails;

namespace AspNetCore.DependencyInjection.Services.Emails;

public interface IEmailSenderService
{
    ValueTask<EmailMessage> SendEmailAsync(EmailMessage message);

    ValueTask<EmailMessage> SendEmailAsync(string receiverEmailAddress);
}