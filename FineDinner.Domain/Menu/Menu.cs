using FineDinner.Domain.Common.Models;
using FineDinner.Domain.Menu.Entities;
using FineDinner.Domain.Menu.ValueObjects;

namespace FineDinner.Domain.Menu;

public sealed class Menu : AggregateRoot<MenuItemId>
{
    private readonly List<MenuSection> _sections = new();
    public string Name { get; }
    public string Description { get; }
    public float AverageRating { get; }

    public IReadOnlyList<MenuSection> Sections => _sections.AsReadOnly();
}