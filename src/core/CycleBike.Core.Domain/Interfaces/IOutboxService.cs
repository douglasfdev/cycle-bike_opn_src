using CycleBike.Core.Domain.Modules.Events.Envelopes;

namespace CycleBike.Core.Domain.Interfaces;

public interface IOutboxService
{
    Task<OutboxEnvelope> EnqueueAsync<T>(T message);
    Task<List<OutboxEnvelope>> GetPendingMessagesAsync();
    Task<OutboxEnvelope?> GetPendingMessageAsync(string id);
    Task DeleteManyByCollectionTimesSpanAsync(TimeSpan timespan);
    Task MarkAsSentAsync(string id);
    Task IncrementAttemptAsync(string id);
    Task UpdateAsync(OutboxEnvelope envelope);
}