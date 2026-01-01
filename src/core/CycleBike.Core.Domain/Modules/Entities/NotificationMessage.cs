using CycleBike.Core.Domain.Modules.Entities.Extensions;

namespace CycleBike.Core.Domain.Modules.Entities;

/// <summary>
/// Representa uma mensagem de notificação.
/// </summary>
/// <param name="ok"></param>
/// <param name="source"></param>
/// <param name="message"></param>
public class NotificationMessage(bool ok, string? source, string? message) : BaseEntity
{
    public bool Ok { get; set; } = ok;
    public string? Source { get; set; } = source;
    public string? Message { get; set; } = message;
};
