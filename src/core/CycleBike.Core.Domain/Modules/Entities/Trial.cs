using CycleBike.Core.Domain.Aggregates;

namespace CycleBike.Core.Domain.Modules.Entities;

public class Trial : AggregateRoot
{
    public Ulid UserId { get; private set; }
    public DateTime TrialStartDate { get; private set; }
    public DateTime TrialEndDate { get; private set; }
    public bool IsActive { get; private set; }
    public int TrialDays { get; private set; }

    private Trial(string  createdBy, Ulid userId, 
        DateTime trialStartDate, DateTime trialEndDate, int trialDays)
        : base(createdBy)
    {
        UserId = userId;
        TrialStartDate = trialStartDate;
        TrialEndDate = trialEndDate;
        IsActive = true;
        TrialDays = trialDays;
    }

    public static Trial Create(Ulid userId, string createdBy, int trialDays)
    {
        var trialEndDate = DateTime.UtcNow.AddDays(trialDays);
        return new Trial(
            createdBy,
            userId,
            DateTime.UtcNow,
            trialEndDate,
            trialDays
        );
    }

    public void Deactivate(string deactivatedBy)
    {
        if (!IsActive) return;
        
        IsActive = false;
        Update(deactivatedBy);
        
        // AddDomainEvent(new TrialDeactivatedEvent(Id, ClientId, UserId, deactivatedBy, UpdatedAt.Value));
    }

    public bool IsExpired()
    {
        return DateTime.UtcNow > TrialEndDate;
    }

    public bool IsInTrialPeriod()
    {
        return IsActive && !IsExpired();
    }
}

public record TrialDeactivatedEvent(
    Ulid TrialId,
    string ClientId,
    Ulid UserId,
    string DeactivatedBy,
    DateTime DeactivatedAt
);