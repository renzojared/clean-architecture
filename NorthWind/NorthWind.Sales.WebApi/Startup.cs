using NorthWind.Sales.Backend.DataContexts.EFCore.Options;

namespace NorthWind.Sales.WebApi;

internal static class Startup
{
    public static WebApplication CreateWebApplication(this WebApplicationBuilder builder)
    {
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddNorthWindSalesServices(dbOptions
            => builder.Configuration.GetSection(DBOptions.SectionKey)
                .Bind(dbOptions));

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