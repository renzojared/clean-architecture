using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using NorthWind.Membership.Backend.AspNetIdentity.Entities;
using NorthWind.Membership.Backend.AspNetIdentity.Options;

namespace NorthWind.Membership.Backend.AspNetIdentity.DataContexts;

public class NorthWindMembershipContext(IOptions<MembershipDbOptions> options) : IdentityDbContext<NorthWindUser>
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(options.Value.ConnectionString);
        base.OnConfiguring(optionsBuilder);
    }
}