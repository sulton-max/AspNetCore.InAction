using AspNetCore.Configuration.Models.Accounts;
using AspNetCore.Configuration.Models.Emails;

namespace AspNetCore.Configuration.Services.Notifications;

public class SmsNotificationService : INotificationsService
{
    public ValueTask<NotificationMessage> SendNotificationAsync(NotificationMessage message)
    {
        Console.WriteLine($"Sending notification via SMS to {message.ReceiverPhoneNumber}...");
        return ValueTask.FromResult(message);
    }

    public ValueTask<NotificationMessage> SendNotificationAsync(User user, string subject, string body)
    {
        var message = new NotificationMessage(subject, body)
        {
            ReceiverPhoneNumber = user.PhoneNumber
        };

        return SendNotificationAsync(message);
    }
}