namespace AspNetCore.RegisteringServices.Models.Emails;

public class NotificationMessage
{
    public string ReceiverEmailAddress { get; set; } = string.Empty;
    public string ReceiverPhoneNumber { get; set; } = string.Empty;
    public string ReceiverFacebookId { get; set; } = string.Empty;
    public string Subject { get; set; }
    public string Body { get; set; }

    public NotificationMessage(string subject, string body)
    {
        Subject = subject;
        Body = body;
    }
}