using MongoDB.Bson;

namespace CycleBike.Core.Domain.Modules.Events.Envelopes;

public class InboxMessage(DateTime processedAt, bool sent, int attempts) : BaseEntityBson(sent, attempts, null, null, processedAt, null)
{
    public DateTime ProcessedAt { get; set; } = processedAt;
}