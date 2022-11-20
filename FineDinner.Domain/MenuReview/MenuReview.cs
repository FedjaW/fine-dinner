using FineDinner.Domain.Common.Models;
using FineDinner.Domain.Dinner.ValueObjects;
using FineDinner.Domain.Host.ValueObjects;
using FineDinner.Domain.Menu.ValueObjects;
using FineDinner.Domain.MenuReview.ValueObjects;

namespace FineDinner.Domain.MenuReview;

public sealed class MenuReview : AggregateRoot<MenuReviewId>
{
    private readonly HostId _hostId;
    private readonly MenuId _menuId;
    private readonly GuestId _guestId;
    private readonly DinnerId _dinnerId;

    public string Rating { get; }
    public string Comment { get; }

    public HostId HostId { get { return _hostId; } }
    public MenuId MenuId { get { return _menuId; } }    
    public GuestId GuestId { get { return _guestId; } }
    public DinnerId DinnerId { get { return _dinnerId; } }

    // todo: add created updated date

    private MenuReview(
        MenuReviewId menuReviewId, 
        string rating, 
        string comment)
    : base(menuReviewId)
    {
        Rating = rating;
        Comment = comment;
    }
}