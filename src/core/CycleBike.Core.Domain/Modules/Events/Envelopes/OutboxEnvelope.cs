using CycleBike.Core.Common.Interfaces;
using CycleBike.Core.Common.MessageBroker;
using CycleBike.Core.Domain.Interfaces;
using MongoDB.Bson.Serialization.Attributes;

namespace CycleBike.Core.Domain.Modules.Events.Envelopes;

public class OutboxEnvelope(
    bool sent,
    int attempts,
    byte[]? data = null,
    string? messageType = null,
    DateTime? sentAt = null,
    DateTime? lastAttempt = null,
    string? status = null
   ) : BaseEntityBson(sent, attempts, messageType, status, sentAt, lastAttempt), IOutboxEnvelope
{
    [BsonElement("data")]
    public byte[]? Data { get; init; } = data;

    [BsonIgnore]
    public RoutingMetadata? RoutingMetadata { get; set; }
}
