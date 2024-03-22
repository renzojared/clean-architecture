using NorthWind.Sales.Backend.DataContexts.EFCore.Options;
using NorthWind.Sales.Backend.SmtpGateways.Options;

namespace NorthWind.Sales.WebApi;

internal static class Startup
{
    public static WebApplication CreateWebApplication(this WebApplicationBuilder builder)
    {
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddNorthWindSalesServices(
            dbOptions
                => builder.Configuration.GetSection(DBOptions.SectionKey).Bind(dbOptions),
            smtpOptions
                => builder.Configuration.GetSection(SmtpOptions.SectionKey).Bind(smtpOptions));

        builder.Services.AddCors(options => options.AddDefaultPolicy(config =>
        {
            config.AllowAnyMethod();
            config.AllowAnyHeader();
            config.AllowAnyOrigin();
        }));

        return builder.Build();
    }

    public static WebApplication ConfigureWebApplication(this WebApplication app)
    {
        app.UseExceptionHandler(builder => { });

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.MapNorthWindSalesEndpoints();
        app.UseCors();

        return app;
    }
}