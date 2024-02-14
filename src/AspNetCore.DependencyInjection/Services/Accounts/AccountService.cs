using AspNetCore.DependencyInjection.Models.Accounts;
using AspNetCore.DependencyInjection.Services.Emails;

namespace AspNetCore.DependencyInjection.Services.Accounts;

public class AccountService : IAccountService
{
    private readonly IEmailSenderService _emailSenderService;

    public AccountService(IEmailSenderService emailSenderService)
    {
        _emailSenderService = emailSenderService;
    }

    public async ValueTask<User> RegisterUser(User user)
    {
        var message = await _emailSenderService.SendEmailAsync(user.EmailAddress);
        return user;
    }
}