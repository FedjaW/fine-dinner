using FineDinner.Domain.Common.Models;
using FineDinner.Domain.MenuAggregate.ValueObjects;

namespace FineDinner.Domain.MenuAggregate.Entities;

public sealed class MenuSection : Entity<MenuSectionId>
{
    private readonly List<MenuItem> _items = new();

    public string Name { get; }
    public string Description { get; }
    public IReadOnlyList<MenuItem> Items => _items.AsReadOnly();
    
    private MenuSection(
        MenuSectionId menuSectionId,
        string name,
        string description)
        : base(menuSectionId)
    {
        Name = name;
        Description = description;
    }

    // Static factory method
    public static MenuSection Create(
        string name, 
        string description)
    {
        return new(
            MenuSectionId.CreateUnique(), 
            name, 
            description);
    }
}