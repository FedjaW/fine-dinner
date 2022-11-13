using ErrorOr;
using FineDinner.Application.Authentication.Common;
using MediatR;

namespace FineDinner.Application.Authentication.Commands.Register;

public record RegisterCommand(
    string FirstName, 
    string LastName, 
    string Email, 
    string Password) : IRequest<ErrorOr<AuthenticationResult>>;
