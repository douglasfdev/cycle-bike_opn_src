using System.Text;
using System.Text.Json;
using CycleBike.Core.Domain.Interfaces;
using CycleBike.Core.Domain.Modules.Envelopes;
using MongoDB.Driver.Linq;

namespace CycleBike.Core.Domain.Services;

public class MongoOutboxService(IMongoDbRepository<OutboxEnvelope> repository) : IMongoOutboxService
{
    public async Task EnqueueAsync<T>(T message)
    {
        var envelope = new OutboxEnvelope
        {
            Id = Guid.NewGuid(),
            Data = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(message)),
            MessageType = typeof(T).AssemblyQualifiedName,
            CreatedAt = DateTime.UtcNow,
            Sent = false,
            Attempts = 0
        };

        await repository.AddAsync(envelope);
    }

    public async Task<List<OutboxEnvelope>> GetPendingMessagesAsync()
    {
        return await repository.Query(x => !x.Sent && x.Attempts < 5)
            .OrderBy(x => x.CreatedAt)
            .Take(50)
            .ToListAsync();
    }

    public async Task<OutboxEnvelope?> GetPendingMessageAsync(Guid id)
    {
        return await repository.GetByIdAsync(id.ToString());
    }

    public async Task DeleteManyByCollectionTimesSpanAsync(TimeSpan timespan)
    {
        var cutoff = DateTime.UtcNow.Subtract(timespan);
        var toDelete = await repository.Query(x => x.Sent && x.SentAt < cutoff)
            .Select(x => x.Id.ToString())
            .ToListAsync();

        await repository.DeleteManyAsync(toDelete);
    }

    public async Task MarkAsSentAsync(Guid id)
    {
        var envelope = await repository.GetByIdAsync(id.ToString());
        if (envelope != null)
        {
            envelope.Sent = true;
            envelope.SentAt = DateTime.UtcNow;
            await repository.UpdateAsync(id.ToString(), envelope);
        }
    }

    public async Task IncrementAttemptAsync(Guid id)
    {
        var envelope = await repository.GetByIdAsync(id.ToString());
        if (envelope != null)
        {
            envelope.Attempts++;
            envelope.LastAttempt = DateTime.UtcNow;
            await repository.UpdateAsync(id.ToString(), envelope);
        }
    }
}