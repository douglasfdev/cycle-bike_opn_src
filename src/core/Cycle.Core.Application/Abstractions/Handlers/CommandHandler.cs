using Cycle.Core.Application.Abstractions.Contracts;
using Cycle.Core.Application.Ports.Handlers;
using Cycle.Core.Application.Responses;

namespace Cycle.Core.Application.Abstractions.Handlers;

public abstract class CommandHandler<TCommand, TResult> : ICommandHandler<TCommand, TResult> where TCommand : ICommand
{
    public abstract Task<ApiResult<TResult>> HandleAsync(TCommand command, CancellationToken cancellationToken);
}