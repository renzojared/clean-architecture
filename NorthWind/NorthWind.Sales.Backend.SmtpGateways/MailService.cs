namespace NorthWind.Sales.Backend.SmtpGateways;

internal class MailService(IOptions<SmtpOptions> options, ILogger<MailService> logger) : IMailService
{
    public async Task SendMailToAdministrator(string subject, string body)
    {
        try
        {
            var message = new MailMessage(options.Value.SenderEmail, options.Value.AdministratorEmail);

            message.Subject = subject;
            message.Body = body;

            var client = new SmtpClient(options.Value.SmtpHost, options.Value.SmtpHostPort)
            {
                Credentials = new NetworkCredential(options.Value.SmtpUserName, options.Value.SmtpPassword),
                EnableSsl = true
            };

            await client.SendMailAsync(message);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, ex.Message);
        }
    }
}