namespace NorthWind.DomainLogs.Entities.ValueObjects;

public class DomainLog(string information)
{
    public DateTime dateTime => DateTime.Now;
    public string Information => information;
}