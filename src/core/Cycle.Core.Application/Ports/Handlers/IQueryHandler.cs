using Cycle.Core.Application.Abstractions.Contracts;
using Cycle.Core.Application.Responses;

namespace Cycle.Core.Application.Ports.Handlers;

public interface IQueryHandler<TQuery, TResponse> where TQuery : IQuery
{
    Task<ApiResult<TResponse>> HandleAsync(TQuery query, CancellationToken cancellationToken);
}