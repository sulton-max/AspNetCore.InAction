using AspNetCore.Configuration.Models.Accounts;
using AspNetCore.Configuration.Models.Emails;

namespace AspNetCore.Configuration.Services.Notifications;

public interface INotificationsService
{
    ValueTask<NotificationMessage> SendNotificationAsync(NotificationMessage message);

    ValueTask<NotificationMessage> SendNotificationAsync(User user, string subject, string body);
}