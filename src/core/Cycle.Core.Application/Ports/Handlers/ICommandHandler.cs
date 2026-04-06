using Cycle.Core.Application.Abstractions.Contracts;
using Cycle.Core.Application.Responses;

namespace Cycle.Core.Application.Ports.Handlers;

public interface ICommandHandler<in TCommand, TResult> where TCommand : ICommand
{
    Task<ApiResult<TResult>> HandleAsync(TCommand command, CancellationToken cancellationToken);
}