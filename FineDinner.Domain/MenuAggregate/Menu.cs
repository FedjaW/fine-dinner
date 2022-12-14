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
        HostId hostId,
        string name,
        string description,
        AverageRating averageRating,
        List<MenuSection> sections,
        DateTime createdDateTime,
        DateTime updatedDateTime)
        : base(menuId)
    {
        HostId = hostId;
        Name = name;
        Description = description;
        AverageRating = averageRating;
        _sections = sections;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

    public static Menu Create(
        HostId hostId,
        string name,
        string description,
        List<MenuSection>? sections)
    {
        return new Menu(
            MenuId.CreateUnique(),
            hostId,
            name,
            description,
            AverageRating.CreateNew(),
            sections ?? new(),
            DateTime.UtcNow,
            DateTime.UtcNow);
    }
}