using AspNetCore.RegisteringServices.Models.Accounts;
using AspNetCore.RegisteringServices.Models.Emails;

namespace AspNetCore.RegisteringServices.Services.Notifications;

public class FacebookNotificationService : INotificationsService
{
    public ValueTask<NotificationMessage> SendNotificationAsync(NotificationMessage message)
    {
        Console.WriteLine($"Sending notification via Facebook to {message.ReceiverPhoneNumber}...");
        return ValueTask.FromResult(message);
    }

    public ValueTask<NotificationMessage> SendNotificationAsync(User user, string subject, string body)
    {
        var message = new NotificationMessage(subject, body)
        {
            ReceiverFacebookId = user.FacebookId
        };

        return SendNotificationAsync(message);
    }
}