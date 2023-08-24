namespace AspNetCore.DependencyInjection.Models.Accounts;

public class User
{
    public string EmailAddress { get; set; }

    public User(string emailAddress)
    {
        EmailAddress = emailAddress;
    }
}