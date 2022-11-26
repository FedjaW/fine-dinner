using FineDinner.Domain.Common.Models;
using FineDinner.Domain.Common.ValueObjects;
using FineDinner.Domain.DinnerAggregate.ValueObjects;
using FineDinner.Domain.HostAggregate.ValueObjects;
using FineDinner.Domain.MenuAggregate.Entities;
using FineDinner.Domain.MenuAggregate.ValueObjects;
using FineDinner.Domain.MenuReviewAggregate.ValueObjects;

namespace FineDinner.Domain.MenuAggregate;

public sealed class Menu : AggregateRoot<MenuId>
{
    private readonly List<MenuSection> _sections = new();
    private readonly List<DinnerId> _dinnerIds = new();
    private readonly List<MenuReviewId> _menuReviewIds = new();

    public string Name { get; }
    public string Description { get; }
    public AverageRating AverageRating { get; }
    public HostId HostId { get; }
    public IReadOnlyList<MenuSection> Sections => _sections.AsReadOnly();
    public IReadOnlyList<DinnerId> DinnerIds => _dinnerIds.AsReadOnly();
    public IReadOnlyList<MenuReviewId> MenuReviewIds => _menuReviewIds.AsReadOnly();
    public DateTime CreatedDateTime { get; }
    public DateTime UpdatedDateTime { get; }

    private Menu(
        MenuId menuId,
        string name,
        string description,
        AverageRating averageRating,
        HostId hostId,
        DateTime createdDateTime,
        DateTime updatedDateTime)
        : base(menuId)
    {
        Name = name;
        Description = description;
        AverageRating = averageRating;
        HostId = hostId;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

    public static Menu Create(
        string name,
        string description,
        AverageRating averageRating,
        HostId hostId)
    {
        return new Menu(
            MenuId.CreateUnique(),
            name, 
            description,
            averageRating,
            hostId,
            DateTime.UtcNow,
            DateTime.UtcNow);
    }
}