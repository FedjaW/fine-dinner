using FineDinner.Api.Common.Mapping;

namespace FineDinner.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddMappings();
        services.AddControllers();
        services.AddSwaggerGen();

        return services;
    }
}