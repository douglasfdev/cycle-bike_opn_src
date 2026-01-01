namespace Cycle.Core.Application.Contracts;

public record Message : ICommand
{
    public DateTimeOffset Timestamp { get; private set; } = DateTimeOffset.UtcNow;
};