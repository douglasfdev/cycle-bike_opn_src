using CycleBike.Core.Domain.Aggregates;

namespace CycleBike.Core.Domain.Modules.Entities;

/// <summary>
/// Representa uma mensagem de notificação.
/// </summary>
/// <param name="ok"></param>
/// <param name="source"></param>
/// <param name="message"></param>
public class NotificationMessage : AggregateRoot
{
    public bool Ok { get; set; }
    public string? Source { get; set; }
    public string? Message { get; set; }

    public NotificationMessage() : base(default!) {}

    private NotificationMessage(bool ok, string? source, string? message, string createdBy) : base(createdBy)
    {
        Ok = ok;
        Source = source;
        Message = message;
    }

    public static NotificationMessage Create(bool ok, string? source, string? message, string createdBy)
        => new(ok, source, message, createdBy);
};
