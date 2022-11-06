using FineDinner.Application.Common.Interfaces.Authentication;
using FineDinner.Application.Common.Interfaces.Persitence;
using FineDinner.Application.Common.Interfaces.Services;
using FineDinner.Infrastructure.Authentication;
using FineDinner.Infrastructure.Persistence;
using FineDinner.Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FineDinner.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, ConfigurationManager configuration)
    {
        services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));

        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();

        services.AddScoped<IUserRepository, UserRepository>();

        return services;
    }
}

// --------------------------------------------------------------------------------------------------------
// Learnings: Singleton vs. Static class
// --------------------------------------------------------------------------------------------------------
// A singleton allows access to a single created instance 
// - that instance (or rather, a reference to that instance) can be passed as a parameter to other methods,
// and treated as a normal object.

// A static class allows only static methods.
// --------------------------------------------------------------------------------------------------------