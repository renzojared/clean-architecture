namespace Microsoft.Extensions.DependencyInjection;

public static class DependencyContainer
{
     public static IServiceCollection AddMembershipIdentityService(this IServiceCollection services,
          Action<MembershipDbOptions> options)
     {
          services.Configure(options);
          services.AddDbContext<NorthWindMembershipContext>();
          services.AddIdentityCore<NorthWindUser>()
               .AddEntityFrameworkStores<NorthWindMembershipContext>();

          services.AddScoped<IMembershipService, MembershipService>();

          return services;
     }
}