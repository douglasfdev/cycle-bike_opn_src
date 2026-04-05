using CycleBike.Core.Common.Interfaces;

namespace CycleBike.Core.Common.MessageBroker;

/// <summary>
/// Metadata de routing que é anexado às mensagens para determinar
/// o exchange e routing key dinamicamente.
/// </summary>
public sealed class RoutingMetadata
{
    public string Process { get; }
    public RoutingKey RoutingKey { get; }
    public string? CorrelationId { get; }
    public DateTime? ScheduledTime { get; }

    public RoutingMetadata(string process, RoutingKey routingKey, string? correlationId = null, DateTime? scheduledTime = null)
    {
        if (string.IsNullOrWhiteSpace(process))
            throw new ArgumentException("Processo não pode ser vazio", nameof(process));
        
        Process = process;
        RoutingKey = routingKey;
        CorrelationId = correlationId ?? Guid.NewGuid().ToString("N");
        ScheduledTime = scheduledTime;
    }

    /// <summary>
    /// Cria metadata para um processo de negócio conhecido.
    /// </summary>
    public static RoutingMetadata ForProcess(string process, RoutingKey routingKey)
        => new(process, routingKey);

    /// <summary>
    /// Cria metadata agendada para processamento futuro.
    /// </summary>
    public static RoutingMetadata Scheduled(string process, RoutingKey routingKey, DateTime scheduledTime)
        => new(process, routingKey, scheduledTime: scheduledTime);
}

/// <summary>
/// Interface de marcador para mensagens que suportam routing dinâmico.
/// </summary>
public interface IRoutableMessage : IMessageBroker
{
    RoutingMetadata? RoutingMetadata { get; set; }
}
