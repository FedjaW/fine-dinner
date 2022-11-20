using FineDinner.Domain.Common.Models;
using FineDinner.Domain.Dinner.ValueObjects;

namespace FineDinner.Domain.Dinner.Entities;

public sealed class Location : Entity<LocationId>
{
    public string Name { get; }
    public string Address { get; }
    public float Latitude { get; }
    public float Longitude { get; }

    private Location(
        LocationId locationId,
        string name,
        string address,
        float latitude,
        float longitude)
        : base(locationId)
    {
        Name = name;
        Address = address;
        Latitude = latitude;
        Longitude = longitude;
    }

    public static Location Create(
        string name,
        string address,
        float latitude,
        float longitude)
    {
        return new(
            LocationId.CreateUnique(),
            name,
            address,
            latitude,
            longitude);
    }
}