using NorthWind.Sales.Backend.DataContexts.EFCore.Guards;

namespace NorthWind.Sales.Backend.DataContexts.EFCore.Services;

public class NorthWindDomainLogsDataContext(IOptions<DBOptions> dbOptions)
    : NorthWindDomainLogsContext(dbOptions), INorthWindDomainLogsDataContext
{
    public async Task AddLogAsync(DomainLog log)
        => await AddAsync(log);

    public async Task SaveChangesAsync()
        => await GuardDbContext.AgainstSaveChangesErrorAsync(this);
}