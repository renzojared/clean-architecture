using Microsoft.EntityFrameworkCore.Design;

namespace NorthWind.Sales.Backend.DataContexts.EFCore.DataContexts;

public class NorthWindDomainLogsContextFactory : IDesignTimeDbContextFactory<NorthWindDomainLogsContext>
{
    public NorthWindDomainLogsContext CreateDbContext(string[] args)
    {
        var dbOptions = Microsoft.Extensions.Options.Options.Create(
            new DBOptions
            {
                DomainLogsConnectionString =
                    "Server=localhost;Database=NorthWindLogsDB;User Id=sa;Password=D@cker09;TrustServerCertificate=True;Encrypt=False;"
            });

        return new NorthWindDomainLogsContext(dbOptions);
    }
}