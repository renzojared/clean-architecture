using NorthWind.Sales.Backend.SmtpGateways;

namespace Microsoft.Extensions.DependencyInjection;

public static class DependencyContainer
{
    public static IServiceCollection AddMailServices(this IServiceCollection services,
        Action<SmtpOptions> configureSmtpOptions)
    {
        services.AddSingleton<IMailService, MailService>();
        services.Configure(configureSmtpOptions);

        return services;
    }
}