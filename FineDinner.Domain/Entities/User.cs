namespace FineDinner.Domain.Entities;

public class User
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;

    // Hint: null! -> null forgiving operator
    // See: https://stackoverflow.com/questions/54724304/what-does-null-statement-mean
}