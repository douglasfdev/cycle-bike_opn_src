namespace Cycle.Core.Application.Contracts;

public interface ICommand
{
    DateTimeOffset Timestamp { get; }
}