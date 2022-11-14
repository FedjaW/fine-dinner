using System.Reflection;
using ErrorOr;
using FineDinner.Application.Authentication.Commands.Register;
using FineDinner.Application.Authentication.Common;
using FineDinner.Application.Common.Behaviors;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace FineDinner.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(typeof(DependencyInjection).Assembly);

        services.AddScoped<
            IPipelineBehavior<RegisterCommand, ErrorOr<AuthenticationResult>>,
            ValidateRegisterCommandBehavior>();

        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        return services;
    }
}