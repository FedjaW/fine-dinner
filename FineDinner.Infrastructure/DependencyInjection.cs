using System.Text;

using FineDinner.Application.Common.Interfaces.Authentication;
using FineDinner.Application.Common.Interfaces.Persistence;
using FineDinner.Application.Common.Interfaces.Persitence;
using FineDinner.Application.Common.Interfaces.Services;
using FineDinner.Infrastructure.Authentication;
using FineDinner.Infrastructure.Persistence;
using FineDinner.Infrastructure.Services;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace FineDinner.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        ConfigurationManager configuration)
    {
        services
            .AddAuth(configuration)
            .AddPersistance();

        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();

        return services;
    }

    private static IServiceCollection AddPersistance(
        this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IMenuRepository, MenuRepository>();

        return services;
    }

    private static IServiceCollection AddAuth(
        this IServiceCollection services,
        ConfigurationManager configuration)
    {
        var jwtSettings = new JwtSettings();
        configuration.Bind("jwtSettings", jwtSettings);

        services.AddSingleton(Options.Create(jwtSettings));
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();

        services.AddAuthentication(defaultScheme: JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options => options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = jwtSettings.Issuer,
                ValidAudience = jwtSettings.Audience,
                IssuerSigningKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(jwtSettings.Secret)),
            });

        return services;
    }
}

// --------------------------------------------------------------------------------------------------------
// Learning: Singleton vs. Static class
// --------------------------------------------------------------------------------------------------------
// A singleton allows access to a single created instance 
// - that instance (or rather, a reference to that instance) can be passed as a parameter to other methods,
// and treated as a normal object.

// A static class allows only static methods.
// --------------------------------------------------------------------------------------------------------