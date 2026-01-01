using Cycle.Core.Application.Abstractions.Contracts;
using Cycle.Core.Application.Ports.Handlers;

namespace Cycle.Core.Application.Handlers;

public abstract class CommandHandler<TCommand> : ICommandHandler<TCommand> where TCommand : ICommand
{
    public abstract Task Handle(TCommand command, CancellationToken cancellationToken);
}