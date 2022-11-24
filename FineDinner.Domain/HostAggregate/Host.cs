using FineDinner.Domain.Common.Models;
using FineDinner.Domain.Common.ValueObjects;
using FineDinner.Domain.HostAggregate.ValueObjects;

namespace FineDinner.Domain.HostAggregate;

public sealed class Host : AggregateRoot<HostId>
{
    public string FirstName { get; }
    public string LastName { get; }
    public string ProfileImage { get; }
    public AverageRating AverageRating { get; }
    public DateTime CreatedDateTime { get; }
    public DateTime UpdatedDateTime { get; }

    private Host(
        HostId hostId,
        string firstName,
        string lastName,
        string profileImage,
        AverageRating averageRating,
        DateTime createdDateTime,
        DateTime updatedDateTime)
    : base(hostId)
    {
        FirstName = firstName;
        LastName = lastName;
        ProfileImage = profileImage;
        AverageRating = averageRating;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

    public static Host Create(
        string firstName,
        string lastName,
        string profileImage,
        AverageRating averageRating)
    {
        return new Host(
            HostId.CreateUnique(),
            firstName,
            lastName,
            profileImage,
            averageRating,
            DateTime.UtcNow,
            DateTime.UtcNow);
    }
}