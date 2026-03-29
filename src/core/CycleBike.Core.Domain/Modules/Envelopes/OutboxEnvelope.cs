using MongoDB.Bson.Serialization.Attributes;

namespace CycleBike.Core.Domain.Modules.Envelopes;

public class OutboxEnvelope
{
    [BsonId]
    public Guid Id { get; set; }
    public byte[] Data { get; set; }
    public string Destination { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public bool Sent { get; set; } = false;
}