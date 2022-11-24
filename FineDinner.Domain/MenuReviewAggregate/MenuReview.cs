using FineDinner.Domain.Common.Models;
using FineDinner.Domain.DinnerAggregate.ValueObjects;
using FineDinner.Domain.GuestAggregate.ValueObjects;
using FineDinner.Domain.HostAggregate.ValueObjects;
using FineDinner.Domain.MenuAggregate.ValueObjects;
using FineDinner.Domain.MenuReviewAggregate.ValueObjects;

namespace FineDinner.Domain.MenuReviewAggregate;

public sealed class MenuReview : AggregateRoot<MenuReviewId>
{
    public string Rating { get; }
    public string Comment { get; }
    public HostId HostId { get; }
    public MenuId MenuId { get; }
    public GuestId GuestId { get; }
    public DinnerId DinnerId { get; }
    public DateTime CreatedDateTime { get; }
    public DateTime UpdatedDateTime { get; }

    private MenuReview(
        MenuReviewId menuReviewId, 
        string rating, 
        string comment,
        HostId hostId,
        MenuId menuId,
        GuestId guestId,
        DinnerId dinnerId,
        DateTime createdDateTime,
        DateTime updatedDateTime)
    : base(menuReviewId)
    {
        Rating = rating;
        Comment = comment;
        HostId = hostId;
        MenuId = menuId;
        GuestId = guestId;
        DinnerId = dinnerId;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

    public static MenuReview Create(
        string rating, 
        string comment,
        HostId hostId,
        MenuId menuId,
        GuestId guestId,
        DinnerId dinnerId)
    {
        return new(
            MenuReviewId.CreateUnique(),
            rating,
            comment,
            hostId,
            menuId,
            guestId,
            dinnerId,
            DateTime.Now,
            DateTime.Now);
    }
}