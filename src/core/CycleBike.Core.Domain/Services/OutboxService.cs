using System.Text.Json;
using CycleBike.Core.Domain.Interfaces;
using CycleBike.Core.Domain.Modules.Events.Envelopes;
using MongoDB.Driver.Linq;

namespace CycleBike.Core.Domain.Services;

public class OutboxService(INoSQLRepository<OutboxEnvelope> repository) : IOutboxService
{
    public async Task<OutboxEnvelope> EnqueueAsync<T>(T message)
    {
        var envelope = new OutboxEnvelope( true, 0, JsonSerializer.SerializeToUtf8Bytes(message), typeof(T).AssemblyQualifiedName);

        await repository.AddAsync(envelope);
        return envelope;
    }

    public async Task<List<OutboxEnvelope>> GetPendingMessagesAsync()
    {
        return await repository.Query(x => !x.Sent && x.Attempts < 5)
            .OrderBy(x => x.CreatedAt)
            .Take(50)
            .ToListAsync();
    }

    public async Task<OutboxEnvelope?> GetPendingMessageAsync(string id)
    {
        return await repository.GetByIdAsync(id);
    }

    public async Task DeleteManyByCollectionTimesSpanAsync(TimeSpan timespan)
    {
        var cutoff = DateTime.UtcNow.Subtract(timespan);
        var toDelete = await repository.Query(x => x.Sent && x.SentAt < cutoff)
            .Select(x => x.Id.ToString())
            .ToListAsync();

        await repository.DeleteManyAsync(toDelete);
    }

    public async Task MarkAsSentAsync(string id)
    {
        var envelope = await repository.GetByIdAsync(id);
        if (envelope != null)
        {
            envelope.SetSent(true, DateTime.UtcNow);
            await repository.UpdateAsync(id, envelope);
        }
    }

    public async Task IncrementAttemptAsync(string id)
    {
        var envelope = await repository.GetByIdAsync(id);
        if (envelope != null)
        {
            envelope.IncrementAttempts(1, DateTime.UtcNow);
            await repository.UpdateAsync(id, envelope);
        }
    }

    public async Task UpdateAsync(OutboxEnvelope envelope)
    {
        await repository.UpdateAsync(envelope.Id, envelope);
    }
}