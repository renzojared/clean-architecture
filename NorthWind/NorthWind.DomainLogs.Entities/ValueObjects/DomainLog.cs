namespace NorthWind.DomainLogs.Entities.ValueObjects;

public class DomainLog(string information, string userName)
{
    public DateTime dateTime => DateTime.Now;
    public string Information => information;
    public string UserName => userName;
}