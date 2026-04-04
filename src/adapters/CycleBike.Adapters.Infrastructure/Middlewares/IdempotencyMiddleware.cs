using CycleBike.Adapters.Infrastructure.Modules.MongoDB.Context;
using CycleBike.Core.Domain.Interfaces;
using CycleBike.Core.Domain.Modules.Events.Envelopes;
using Wolverine;

namespace CycleBike.Adapters.Infrastructure.Middlewares;

public static class IdempotencyMiddleware
{
    public static async Task<HandlerContinuation> Before(
        Envelope envelope, 
        IMongoContext context, 
        INoSQLRepository<InboxMessage> inboxRepo)
    {
        var session = await context.StartSessionAsync();
        session.StartTransaction();

        var alreadyProcessed = await inboxRepo.GetByIdAsync(envelope.Id.ToString()) != null;

        if (alreadyProcessed)
        {
            await session.CommitTransactionAsync();
            return HandlerContinuation.Stop; 
        }

        return HandlerContinuation.Continue;
    }

    public static async Task After(
        Envelope envelope, 
        IMongoContext context, 
        INoSQLRepository<InboxMessage> inboxRepo)
    {
        await inboxRepo.AddAsync(new InboxMessage(DateTime.UtcNow, false, 0));

        if (context.Session is { IsInTransaction: true })
        {
            await context.Session.CommitTransactionAsync();
        }
    }
}