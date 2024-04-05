namespace NorthWind.DomainLogs.Entities.Interfaces;

public interface IDomainLogger
{
    Task LogInformation(DomainLog log);
}