using AspNetCore.Configuration.Models.Accounts;

namespace AspNetCore.Configuration.Services.Accounts;

public interface IAccountService
{
    ValueTask<User> RegisterUser(User user);
}