namespace NorthWind.Sales.Backend.SmtpGateways.Options;

public class SmtpOptions
{
    public const string SectionKey = nameof(SmtpOptions);
    public string SmtpHost { get; set; }
    public int SmtpHostPort { get; set; }
    public string SmtpUserName { get; set; }
    public string SmtpPassword { get; set; }
    public string SenderEmail { get; set; }
    public string AdministratorEmail { get; set; }
}