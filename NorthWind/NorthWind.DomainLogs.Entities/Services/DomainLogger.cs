using NorthWind.DomainLogs.Entities.Interfaces;

namespace NorthWind.DomainLogs.Entities.Services;

internal class DomainLogger(IDomainLogsRepository repository) : IDomainLogger
{
    public async Task LogInformation(DomainLog log)
    {
        await repository.Add(log);
        await repository.SaveChanges();
    }
}