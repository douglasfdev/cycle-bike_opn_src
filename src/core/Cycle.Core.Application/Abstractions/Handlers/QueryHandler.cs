using Cycle.Core.Application.Abstractions.Contracts;
using Cycle.Core.Application.Ports.Handlers;
using Cycle.Core.Application.Responses;

namespace Cycle.Core.Application.Abstractions.Handlers;

public abstract class QueryHandler<TQuery, TResponse> : IQueryHandler<TQuery, TResponse> where TQuery : IQuery
{
    public abstract Task<ApiResult<TResponse>> HandleAsync(TQuery query, CancellationToken cancellationToken);
}