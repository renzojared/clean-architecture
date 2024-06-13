namespace NorthWind.Membership.Backend.AspNetIdentity.DataContexts;

internal class NorthWindMembershipContextFactory : IDesignTimeDbContextFactory<NorthWindMembershipContext>
{
    public NorthWindMembershipContext CreateDbContext(string[] args)
    {
        var options = Microsoft.Extensions.Options.Options.Create(new MembershipDbOptions
        {
            ConnectionString =
                "Server=localhost,55002;Database=NorthWindUsersDB;User Id=sa;Password=D@cker09;TrustServerCertificate=True;Encrypt=False;"
        });
        return new NorthWindMembershipContext(options);
    }
}