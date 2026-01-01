using Cycle.Core.Application.Abstractions.Contracts;
using Cycle.Core.Application.Ports.Handlers;

namespace Cycle.Core.Application.Handlers;

public abstract class QueryHandler<TQuery, TResponse> : IQueryHandler<TQuery, TResponse> where TQuery : IQuery
{
    public abstract Task<TResponse> Handle(TQuery query, CancellationToken cancellationToken);
}