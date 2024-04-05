namespace NorthWind.DomainLogs.Entities.Interfaces;

public interface IDomainLogsRepository : IUnitOfWork
{
    Task Add(DomainLog log);
}