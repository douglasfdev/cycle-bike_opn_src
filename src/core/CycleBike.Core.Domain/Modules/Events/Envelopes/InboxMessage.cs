namespace CycleBike.Core.Domain.Modules.Events.Envelopes;

public class InboxMessage(DateTime processedAt) : BaseEntityBson
{
    public DateTime ProcessedAt { get; set; } = processedAt;
}