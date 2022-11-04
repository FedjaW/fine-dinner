using FineDinner.Application.Common.Interfaces.Authentication;
using FineDinner.Application.Common.Interfaces.Services;
using FineDinner.Infrastructure.Authentication;
using FineDinner.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace FineDinner.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
        services.AddScoped<IDateTimeProvider, DateTimeProvider>();

        return services;
    }
}