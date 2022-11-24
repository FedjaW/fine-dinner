using FineDinner.Domain.BillAggregate.ValueObjects;
using FineDinner.Domain.Common.Models;
using FineDinner.Domain.DinnerAggregate.ValueObjects;
using FineDinner.Domain.GuestAggregate.ValueObjects;

namespace FineDinner.Domain.DinnerAggregate.Entities;

public sealed class DinnerReservation : Entity<DinnerReservationId>
{
    public int GuestCount { get; }
    public ReservationStatus ReservationStatus { get; } 
    public GuestId GuestId { get; }
    public BillId BillId { get; }
    public DateTime ArrivalDateTime { get; }
    public DateTime CreatedDateTime { get; }
    public DateTime UpdatedDateTime { get; }

    private DinnerReservation(
        DinnerReservationId dinnerReservationId,
        int guestCount,
        ReservationStatus reservationStatus,
        GuestId guestId,
        BillId billId,
        DateTime arrivalDateTime,
        DateTime createdDateTime,
        DateTime updatedDateTime)
        : base(dinnerReservationId)
    {
        GuestCount = guestCount;
        ReservationStatus = reservationStatus;
        GuestId = guestId;
        BillId = billId;
        ArrivalDateTime = arrivalDateTime;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

    // Static factory method
    public static DinnerReservation Create(
        int guestCount,
        ReservationStatus reservationStatus,
        GuestId guestId,
        BillId billId, 
        DateTime arrivalDateTime)
    {
        return new(
            DinnerReservationId.CreateUnique(),
            guestCount,
            reservationStatus,
            guestId,
            billId,
            arrivalDateTime,
            DateTime.UtcNow,
            DateTime.UtcNow);
    }
}
