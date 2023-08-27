using System.Net;
using System.Net.Mail;
using AspNetCore.RegisteringServices.Models.Accounts;
using AspNetCore.RegisteringServices.Models.Configurations;
using AspNetCore.RegisteringServices.Models.Emails;

namespace AspNetCore.RegisteringServices.Services.Notifications;

public class EmailNotificationsService : INotificationsService
{
    private readonly EmailSenderSettings _emailSenderSettings;

    private Lazy<SmtpClient> SmtpClientInstance { get; init; }

    public EmailNotificationsService(SmtpServerSettings smtpServerSettings, EmailSenderSettings emailSenderSettings)
    {
        var smtpServerSettingsValue = smtpServerSettings;
        _emailSenderSettings = emailSenderSettings;

        SmtpClientInstance = new Lazy<SmtpClient>(() => new SmtpClient(smtpServerSettingsValue.Host, smtpServerSettingsValue.Port)
        {
            EnableSsl = true,
            Credentials = new NetworkCredential(smtpServerSettingsValue.EmailAddress, smtpServerSettingsValue.Password)
        });
    }

    public async ValueTask<NotificationMessage> SendNotificationAsync(NotificationMessage message)
    {
        try
        {
            var mail = new MailMessage(_emailSenderSettings.SenderEmailAddress, message.ReceiverEmailAddress);
            mail.Subject = message.Subject;
            mail.Body = message.Body;

            Console.WriteLine($"Sending notification via Email to {message.ReceiverEmailAddress}...");
            await SmtpClientInstance.Value.SendMailAsync(mail);
        }
        catch (Exception e)
        {
            // ignored
        }

        return message;
    }

    public ValueTask<NotificationMessage> SendNotificationAsync(User user, string subject, string body)
    {
        var message = new NotificationMessage(subject, body)
        {
            ReceiverEmailAddress = user.EmailAddress
        };

        return SendNotificationAsync(message);
    }
}