using FineDinner.Api.Common.Mapping;

using Microsoft.OpenApi.Models;

namespace FineDinner.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddMappings();
        services.AddControllers();
        services.AddSwaggerGen(s =>
        {
            s.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Description = "JWT Authorization header using the Bearer scheme (Example: 'Bearer 12345abcdef')",
                Name = "Authorization",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Bearer",
                BearerFormat = "JWT",
            });

            var securityScheme = new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer",
                },
            };
            var securityRequirement = new OpenApiSecurityRequirement();
            securityRequirement.Add(securityScheme, new string[] { });
            s.AddSecurityRequirement(securityRequirement);
        });

        return services;
    }
}