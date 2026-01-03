using Cycle.Core.Application.Contracts;
using ICommand = Cycle.Core.Application.Abstractions.Contracts.ICommand;

namespace Cycle.Core.Application.Schemas.Commands;

public abstract class ProductCommands
{
    public record CreateProduct(string Name, decimal Price, string Description) : Message, ICommand;
}