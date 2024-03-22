namespace NorthWind.Sales.Backend.BusinessObjects.Interfaces.Common;

public interface IMailService
{
    Task SendMailToAdministrator(string subject, string body);
}