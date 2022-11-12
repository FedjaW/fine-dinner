using ErrorOr;
using FineDinner.Application.Services.Authentication.Common;

namespace FineDinner.Application.Services.Authentication.Commands;

public interface IAuthenticationCommandService
{
    ErrorOr<AuthenticationResult> Register(string firstName, string lastName, string email, string password);
}