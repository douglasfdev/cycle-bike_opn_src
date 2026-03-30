using CycleBike.Core.Domain.Modules.Envelopes;

namespace CycleBike.Core.Domain.Interfaces;

public interface IMongoOutboxService
{
    Task EnqueueAsync<T>(T message);
     Task<List<OutboxEnvelope>> GetPendingMessagesAsync();
     Task<OutboxEnvelope?> GetPendingMessageAsync(Guid id);
     Task DeleteManyByCollectionTimesSpanAsync(TimeSpan timespan);
     Task MarkAsSentAsync(Guid id);
     Task IncrementAttemptAsync(Guid id);
}