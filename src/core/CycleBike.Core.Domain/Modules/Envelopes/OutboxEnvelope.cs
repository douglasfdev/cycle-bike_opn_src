using MongoDB.Bson.Serialization.Attributes;

namespace CycleBike.Core.Domain.Modules.Envelopes;

public class OutboxEnvelope
{
    [BsonId] public Guid Id { get; set; } = Guid.NewGuid();
    public byte[] Data { get; set; } = null!;
    public string? MessageType { get; set; }
    public DateTime CreatedAt { get; set; }
    public bool Sent { get; set; }
    public DateTime? SentAt { get; set; }
    public int Attempts { get; set; }
    public DateTime? LastAttempt { get; set; }
}