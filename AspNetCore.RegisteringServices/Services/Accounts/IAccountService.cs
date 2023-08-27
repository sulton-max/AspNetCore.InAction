using AspNetCore.RegisteringServices.Models.Accounts;

namespace AspNetCore.RegisteringServices.Services.Accounts;

public interface IAccountService
{
    ValueTask<User> RegisterUser(User user);
}