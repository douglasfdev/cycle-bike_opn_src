using CycleBike.Core.Domain.Enums;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CycleBike.Core.Domain.Modules.Events;

public abstract class BaseEntityBson
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; protected init; } = null!;
    public string? MessageType { get; set; }
    public DateTime CreatedAt { get; set; }
    public bool Sent { get; set; }
    public DateTime? SentAt { get; set; }
    public int Attempts { get; set; }
    public DateTime? LastAttempt { get; set; }
    public string Status { get; set; } = nameof(StatusProcess.InProgress).ToLowerInvariant();
}