using CycleBike.Core.Domain.Enums;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CycleBike.Core.Domain.Modules.Events;

public abstract class BaseEntityBson(bool sent, int attempts, string? messageType, string? status, DateTime? sentAt, DateTime? lastAttempt)
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; private set; } = ObjectId.GenerateNewId().ToString();
    public string? MessageType { get; private set; } = messageType;
    public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
    public bool Sent { get; private set; } = sent;
    public DateTime? SentAt { get; private set; } = sentAt;
    public int Attempts { get; private set; } = attempts;
    public DateTime? LastAttempt { get; private set; } = lastAttempt;
    public string Status { get; private set; } = status ?? nameof(StatusProcess.Initied).ToLowerInvariant();

    public void SetSent(bool sent, DateTime sendAt)
    {
        Sent = sent;
        SentAt = sendAt;
    }
    
    public void IncrementAttempts(int attempts, DateTime lastAttempted)
    {
        Attempts += attempts;
        LastAttempt = lastAttempted;
    }
}