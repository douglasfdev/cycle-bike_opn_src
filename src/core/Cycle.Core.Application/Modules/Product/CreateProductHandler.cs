using Cycle.Core.Application.Abstractions.Handlers;
using Cycle.Core.Application.Schemas;
using Cycle.Core.Application.Schemas.Commands;

namespace Cycle.Core.Application.Modules.Product;

public class CreateProductHandler() : CommandHandler<Command.ProductCommand.CreateProduct>
{
    public override Task Handle(ProductCommands.CreateProduct command, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}