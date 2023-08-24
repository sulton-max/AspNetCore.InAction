using System.Net;
using System.Net.Mail;
using AspNetCore.DependencyInjection.Models.Configurations;
using AspNetCore.DependencyInjection.Models.Emails;

namespace AspNetCore.DependencyInjection.Services.Emails;

public class EmailSenderService : IEmailSenderService
{
    private readonly EmailSenderSettings _emailSenderSettings;

    private Lazy<SmtpClient> SmtpClientInstance { get; init; }

    public EmailSenderService(SmtpServerSettings smtpServerSettings, EmailSenderSettings emailSenderSettings)
    {
        var smtpServerSettingsValue = smtpServerSettings;
        _emailSenderSettings = emailSenderSettings;

        SmtpClientInstance = new Lazy<SmtpClient>(() => new SmtpClient(smtpServerSettingsValue.Host, smtpServerSettingsValue.Port)
        {
            EnableSsl = true,
            Credentials = new NetworkCredential(smtpServerSettingsValue.EmailAddress, smtpServerSettingsValue.Password)
        });
    }

    public async ValueTask<EmailMessage> SendEmailAsync(EmailMessage message)
    {
        try
        {
            var mail = new MailMessage(_emailSenderSettings.SenderEmailAddress, message.ReceiverEmailAddress);
            mail.Subject = message.Subject;
            mail.Body = message.Body;

            await SmtpClientInstance.Value.SendMailAsync(mail);
            message.IsSent = true;
        }
        catch (Exception e)
        {
            // ignored
        }

        return message;
    }

    public ValueTask<EmailMessage> SendEmailAsync(string receiverEmailAddress)
    {
        var emailMessage = new EmailMessage(receiverEmailAddress, "Registration complete", "You have successfully registered to our website.");
        return SendEmailAsync(emailMessage);
    }
}