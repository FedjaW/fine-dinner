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



}