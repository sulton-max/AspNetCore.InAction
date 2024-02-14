namespace AspNetCore.Configuration.Models.Accounts;

public class User
{
    public string EmailAddress { get; set; }
    public string PhoneNumber { get; set; }
    public string FacebookId { get; set; }

    public User(string emailAddress, string phoneNumber, string facebookId)
    {
        EmailAddress = emailAddress;
        PhoneNumber = phoneNumber;
        FacebookId = facebookId;
    }
}