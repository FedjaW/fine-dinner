using ErrorOr;
using FineDinner.Application.Authentication.Common;
using MediatR;

namespace FineDinner.Application.Authentication.Queries.Login;

public record LoginQuery(
    string Email,
    string Password) : IRequest<ErrorOr<AuthenticationResult>>;
