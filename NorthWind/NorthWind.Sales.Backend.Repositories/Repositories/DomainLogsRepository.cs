using NorthWind.DomainLogs.Entities.Interfaces;
using DomainLogEnterprise = NorthWind.DomainLogs.Entities.ValueObjects.DomainLog;

namespace NorthWind.Sales.Backend.Repositories.Repositories;

internal class DomainLogsRepository(INorthWindDomainLogsDataContext context) : IDomainLogsRepository
{
    public async Task SaveChanges()
        => await context.SaveChangesAsync();

    public async Task Add(DomainLogEnterprise log)
        =>
            await context.AddLogAsync(new DomainLog
            {
                CreatedDate = log.dateTime,
                Information = log.Information
            });
}