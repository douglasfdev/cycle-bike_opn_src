using CycleBike.Core.Domain.Aggregates;

namespace CycleBike.Core.Domain.Modules.Entities;

/// <summary>
/// Representa uma mensagem de notificação.
/// </summary>
/// <param name="ok"></param>
/// <param name="source"></param>
/// <param name="message"></param>
public class NotificationMessage(bool ok, string? source, string? message) : AggregateRoot
{
    public bool Ok { get; set; } = ok;
    public string? Source { get; set; } = source;
    public string? Message { get; set; } = message;
};
