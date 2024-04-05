namespace NorthWind.Sales.Backend.Repositories.Interfaces;

public interface INorthWindDomainLogsDataContext
{
    Task AddLogAsync(DomainLog log);
    Task SaveChangesAsync();
}