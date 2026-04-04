using MongoDB.Bson;

namespace CycleBike.Core.Domain.Modules.Events.Envelopes;

public class OutboxEnvelope(byte[]? data, bool sent, string? messageType, DateTime? sentAt, int attempts, DateTime? lastAttempt, string status) : BaseEntityBson(sent, attempts, messageType, status, sentAt, lastAttempt)
{
    public byte[]? Data { get; } = data;
}