namespace NorthWind.Membership.Backend.AspNetIdentity.DataContexts;

public class NorthWindMembershipContext(IOptions<MembershipDbOptions> options) : IdentityDbContext<NorthWindUser>
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(options.Value.ConnectionString);
        base.OnConfiguring(optionsBuilder);
    }
}