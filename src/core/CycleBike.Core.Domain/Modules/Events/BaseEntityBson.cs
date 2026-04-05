using CycleBike.Core.Domain.Enums;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CycleBike.Core.Domain.Modules.Events;

public abstract class BaseEntityBson(bool sent, int attempts, string? messageType, string? status, DateTime? sentAt, DateTime? lastAttempt)
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; } = ObjectId.GenerateNewId().ToString();
    public string? MessageType { get; set; } = messageType;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public bool Sent { get; set; } = sent;
    public DateTime? SentAt { get; set; } = sentAt;
    public int Attempts { get; set; } = attempts;
    public DateTime? LastAttempt { get; set; } = lastAttempt;
    public string Status { get; set; } = status ?? nameof(StatusProcess.Initied).ToLowerInvariant();

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