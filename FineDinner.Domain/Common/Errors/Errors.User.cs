using ErrorOr;

namespace FineDinner.Domain.Common.Errors;

public static partial class Errors
{
    public static class User
    {
        public static Error DuplicatedEmail = Error.Validation(
            code: "User.DuplicateEmail",
            description: "Email is already in use.");
    }
}