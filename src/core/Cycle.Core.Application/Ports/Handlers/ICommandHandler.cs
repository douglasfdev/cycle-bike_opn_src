using Cycle.Core.Application.Abstractions.Contracts;

namespace Cycle.Core.Application.Ports.Handlers;

public interface ICommandHandler<in TCommand> where TCommand : ICommand
{
    Task Handle(TCommand command, CancellationToken cancellationToken);
}