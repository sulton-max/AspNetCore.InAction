using AspNetCore.RegisteringServices.Models.Accounts;
using AspNetCore.RegisteringServices.Services.Notifications;

namespace AspNetCore.RegisteringServices.Services.Accounts;

public class AccountService : IAccountService
{
    private readonly IEnumerable<INotificationsService> _notificationsServices;

    public AccountService(IEnumerable<INotificationsService> notificationsServices)
    {
        _notificationsServices = notificationsServices;
    }

    public async ValueTask<User> RegisterUser(User user)
    {
        foreach (var notificationsService in _notificationsServices)
            await notificationsService.SendNotificationAsync(user,
                "Registration complete",
                "You have successfully registered to our website.");

        return user;
    }
}