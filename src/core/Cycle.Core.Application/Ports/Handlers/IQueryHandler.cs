using Cycle.Core.Application.Abstractions.Contracts;

namespace Cycle.Core.Application.Ports.Handlers;

public interface IQueryHandler<TQuery, TResponse> where TQuery : IQuery
{
    Task<TResponse> Handle(TQuery query, CancellationToken cancellationToken);
}