namespace AspNetCore.RegisteringServices.Models.Configurations;

public class SmtpServerSettings
{
    public string Host { get; set; }
    public int Port { get; set; }
    public string EmailAddress { get; set; }
    public string Password { get; set; }
}