
using ErrorOr;
using FluentValidation;
using MediatR;

namespace FineDinner.Application.Common.Behaviors;

public class ValidationBehavior<TRequest, TResponse> :
    IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
    where TResponse : IErrorOr
{
    private readonly IValidator<TRequest>? _validator;

    public ValidationBehavior(IValidator<TRequest>? validator = null)
    {
        _validator = validator;
    }

    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        if (_validator == null)
        {
            return await next();
        }

        var validationResult = await _validator.ValidateAsync(request, cancellationToken);

        if (validationResult.IsValid)
        {
            return await next();
        }

        var errors = validationResult.Errors
            .ConvertAll(validationFailure => Error.Validation
                (validationFailure.PropertyName,
                validationFailure.ErrorMessage));

        return (dynamic)errors;
        // Note: in runtime dynamic will try to convert the erros list to an ErrorOr object.
        // If it can not convert, it will throw a runtime-exception.
        // You usually don't want to use dynamic unless you know what you're doing.
    }
}