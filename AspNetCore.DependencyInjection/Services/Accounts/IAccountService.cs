using AspNetCore.DependencyInjection.Models.Accounts;

namespace AspNetCore.DependencyInjection.Services.Accounts;

public interface IAccountService
{
    ValueTask<User> RegisterUser(User user);
}