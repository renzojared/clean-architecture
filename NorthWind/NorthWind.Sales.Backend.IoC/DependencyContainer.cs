using NorthWind.Sales.Backend.DataContexts.EFCore.Options;
using NorthWind.Sales.Backend.SmtpGateways.Options;

namespace Microsoft.Extensions.DependencyInjection;

public static class DependencyContainer
{
    public static IServiceCollection AddNorthWindSalesServices
        (this IServiceCollection services,
            Action<DBOptions> configureDbOptions,
            Action<SmtpOptions> configureSmtpOptions)
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
            .AddUnhandledExceptionHandler()
            .AddEventServices()
            .AddMailServices(configureSmtpOptions)
            .AddDomainLogsServices()
            .AddWindowsTransactionServices();

        return services;
    }
}