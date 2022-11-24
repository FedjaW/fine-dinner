using FineDinner.Domain.Common.Models;
using FineDinner.Domain.Menu.ValueObjects;

namespace FineDinner.Domain.Menu.Entities;

public sealed class MenuItem : Entity<MenuItemId>
{
    public string Name { get; }
    public string Description { get; }

    private MenuItem(
        MenuItemId menuItemId,
        string name,
        string description)
        : base(menuItemId)
    {
        Name = name;
        Description = description;
    }

    // static factory method
    public static MenuItem Create(
        string name,
        string description)
    {
        return new(
            MenuItemId.CreateUnique(),
            name,
            description);
    }
}