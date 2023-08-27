using AspNetCore.RegisteringServices.Models.Accounts;
using AspNetCore.RegisteringServices.Models.Emails;

namespace AspNetCore.RegisteringServices.Services.Notifications;

public interface INotificationsService
{
    ValueTask<NotificationMessage> SendNotificationAsync(NotificationMessage message);

    ValueTask<NotificationMessage> SendNotificationAsync(User user, string subject, string body);
}