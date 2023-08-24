namespace AspNetCore.DependencyInjection.Models.Emails;

public class EmailMessage
{
    public string ReceiverEmailAddress { get; set; }
    public string Subject { get; set; }
    public string Body { get; set; }
    public bool IsSent { get; set; }

    public EmailMessage(string receiverEmailAddress, string subject, string body)
    {
        ReceiverEmailAddress = receiverEmailAddress;
        Subject = subject;
        Body = body;
    }
}