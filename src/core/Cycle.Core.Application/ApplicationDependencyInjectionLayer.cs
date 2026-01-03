using Cycle.Core.Application.Modules.Product;
using Cycle.Core.Application.Ports.Handlers;
using Cycle.Core.Application.Schemas.Commands;
using Microsoft.Extensions.DependencyInjection;

namespace Cycle.Core.Application;

public static class ApplicationDependencyInjectionLayer
{
    public static void AddApplicationLayer(this IServiceCollection services)
    {
        services.AddTransient<ICommandHandler<ProductCommands.CreateProduct>, CreateProductHandler>();
    }
}