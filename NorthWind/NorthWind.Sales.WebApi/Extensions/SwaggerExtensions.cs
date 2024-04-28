using Microsoft.OpenApi.Models;

namespace NorthWind.Sales.WebApi.Extensions;

public static class SwaggerExtensions
{
    public static IServiceCollection AddSwaggerGenBearer(this IServiceCollection services)
    {
        services.AddSwaggerGen(opt =>
        {
            opt.AddSecurityDefinition("BearerToken",
                new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Description = "Proporcionar el valor del token.",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "Bearer"
                });
            opt.AddSecurityRequirement(
                new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "BearerToken"
                            },
                        },
                        new string[] { }
                    }
                });
        });
        
        return services;
    }
}