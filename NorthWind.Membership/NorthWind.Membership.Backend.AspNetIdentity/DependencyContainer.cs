using NorthWind.Membership.Backend.AspNetIdentity.DataContexts;
using NorthWind.Membership.Backend.AspNetIdentity.Entities;
using NorthWind.Membership.Backend.AspNetIdentity.Options;
using NorthWind.Membership.Backend.AspNetIdentity.Services;
using NorthWind.Membership.Backend.Core.Interfaces.Common;

namespace Microsoft.Extensions.DependencyInjection;

public static class DependencyContainer
{
     public static IServiceCollection AddMembershipIdentityService(this IServiceCollection services,
          Action<MembershipDbOptions> options)
     {
          services.AddDbContext<NorthWindMembershipContext>();
          services.AddIdentityCore<NorthWindUser>()
               .AddEntityFrameworkStores<NorthWindMembershipContext>();

          services.AddScoped<IMembershipService, MembershipService>();
          services.Configure(options);
          return services;
     }
}