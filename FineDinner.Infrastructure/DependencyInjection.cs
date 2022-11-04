using FineDinner.Application.Common.Interfaces.Authentication;
using FineDinner.Infrastructure.Authentication;
using Microsoft.Extensions.DependencyInjection;

namespace FineDinner.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();

        return services;
    }
}