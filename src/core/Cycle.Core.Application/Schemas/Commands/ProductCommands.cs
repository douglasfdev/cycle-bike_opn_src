using Cycle.Core.Application.Contracts;
using CycleBike.Core.Domain.Requests;
using ICommand = Cycle.Core.Application.Abstractions.Contracts.ICommand;

namespace Cycle.Core.Application.Schemas.Commands;

public abstract class ProductCommands
{
    public record CreateProduct(string Name, decimal Price, string Description) : Message, ICommand;
    public record CreateCachedProduct(string Name, decimal Price, string Description) : Message, ICommand;
    public record UpdateProduct(Ulid Id, string Name, decimal Price, string Description) : Message, ICommand;
    public record DeleteProduct(Ulid Id, bool IsDeleted) : Message, ICommand;
    public record PublishProduct(ProductRequest.CreateProduct Request) : Message, ICommand;
}
