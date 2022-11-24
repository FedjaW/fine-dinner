using FineDinner.Domain.Common.Models;
using FineDinner.Domain.Dinner.ValueObjects;
using FineDinner.Domain.Guest.ValueObjects;
using FineDinner.Domain.Host.ValueObjects;
using FineDinner.Domain.Menu.ValueObjects;
using FineDinner.Domain.MenuReview.ValueObjects;

namespace FineDinner.Domain.MenuReview;

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