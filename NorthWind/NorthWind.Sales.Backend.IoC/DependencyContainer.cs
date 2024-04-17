using NorthWind.Membership.Backend.AspNetIdentity.Options;
using NorthWind.Sales.Backend.DataContexts.EFCore.Options;
using NorthWind.Sales.Backend.SmtpGateways.Options;

namespace Microsoft.Extensions.DependencyInjection;

public static class DependencyContainer
{
    public static IServiceCollection AddNorthWindSalesServices
        (this IServiceCollection services,
            Action<DBOptions> configureDbOptions,
            Action<SmtpOptions> configureSmtpOptions,
            Action<MembershipDbOptions> configureMembershipDbOptions)
    {
        services
            .AddUseCasesServices()
            .AddRepositories()
            .AddDataContexts(configureDbOptions)
            .AddPresenters()
            .AddValidators()
            .AddValidationService()
            .AddValidationExceptionHandler()
            .AddUpdateExceptionHandler()
            .AddUnauthorizedAccessExceptionHandler()
            .AddUnhandledExceptionHandler()
            .AddEventServices()
            .AddMailServices(configureSmtpOptions)
            .AddDomainLogsServices()
            .AddWindowsTransactionServices()
            .AddUserServices()
            .AddMembershipCoreServices()
            .AddMembershipIdentityService(configureMembershipDbOptions);

        return services;
    }
}