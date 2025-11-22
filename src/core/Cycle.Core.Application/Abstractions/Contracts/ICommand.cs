namespace Cycle.Core.Application.Abstractions.Contracts;

public interface ICommand
{
    DateTimeOffset Timestamp { get; }
}