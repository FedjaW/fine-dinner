using FineDinner.Domain.Common.Models;
using FineDinner.Domain.Common.ValueObjects;
using FineDinner.Domain.Dinner.Entities;
using FineDinner.Domain.Dinner.ValueObjects;

namespace FineDinner.Domain.Dinner;

public sealed class Dinner : AggregateRoot<DinnerId>
{
    private readonly List<DinnerReservation> _dinnerReservations = new();
    
    public string Name { get; }
    public string Description { get; }
    public string ImageUrl { get; }
    public string Status { get; }
    public bool IsPublic { get; }
    public int MaxGuests { get; }
    public Price Price { get; }
    public DateTime StartDateTime { get; }
    public DateTime EndDateTime { get; }
    public Location Location { get; }
    public DateTime CreatedDateTime { get; }
    public DateTime UpdatedDateTime { get; }
    public IReadOnlyList<DinnerReservation> DinnerReservations => _dinnerReservations.AsReadOnly();

    private Dinner(
        DinnerId dinnerId,
        string name,
        string description,
        string imageUrl,
        string status,
        bool isPublic,
        int maxGuests,
        Price price,
        DateTime startDateTime,
        DateTime endDateTime,
        Location location,
        DateTime createdDateTime,
        DateTime updatedDateTime)
        : base(dinnerId)
    {
        Name = name;
        Description = description;
        ImageUrl = imageUrl;
        Status = status;
        IsPublic = isPublic;
        MaxGuests = maxGuests;
        Price = price;
        StartDateTime = startDateTime;
        EndDateTime = endDateTime;
        Location = location;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

    public static Dinner Create(
        string name,
        string description,
        string imageUrl,
        string status,
        bool isPublic,
        int maxGuests,
        Price price,
        DateTime startDateTime,
        DateTime endDateTime,
        Location location)
     {
        return new Dinner(
            DinnerId.CreateUnique(),
            name,
            description,
            imageUrl,
            status,
            isPublic,
            maxGuests,
            price,
            startDateTime,
            endDateTime,
            location,
            DateTime.UtcNow,
            DateTime.UtcNow);
    }

}