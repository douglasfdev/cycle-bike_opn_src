using System.Text;
using CycleBike.Core.Domain.Interfaces;
using Microsoft.Extensions.Logging;
using Wolverine;

namespace CycleBike.Core.Domain.Services;

public class OutboxRelayServiceService(ILogger<OutboxRelayServiceService> logger, IMessageBus bus, IOutboxService outboxService): IOutboxRelayService
{
    public async Task RelayAsync<T>(T message)
    {
        var pendingMessages = await outboxService.GetPendingMessagesAsync();
        
        foreach (var envelope in pendingMessages)
        {
            try
            {
                var messageType = Type.GetType(envelope.MessageType!);
                if (messageType == null)
                {
                    logger.LogWarning("Tipo de mensagem desconhecido: {Type}", envelope.MessageType);
                    continue;
                }

                var json = Encoding.UTF8.GetString(envelope.Data);

                if (message != null)
                {
                    await bus.PublishAsync(message);

                    await outboxService.MarkAsSentAsync(envelope.Id);
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Falha ao processar envelope {Id}. Incrementando tentativa.", envelope.Id);
                await outboxService.IncrementAttemptAsync(envelope.Id);
            }
        }
    }
}