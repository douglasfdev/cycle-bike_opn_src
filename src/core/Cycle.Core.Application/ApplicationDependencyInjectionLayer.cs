using Cycle.Core.Application.Modules.Product;
using Cycle.Core.Application.Ports.Handlers;
using Cycle.Core.Application.Responses;
using Cycle.Core.Application.Schemas;
using Cycle.Core.Application.Schemas.Commands;
using Cycle.Core.Application.Schemas.Queries;
using CycleBike.Core.Domain.Modules.Entities;
using CycleBike.Core.Domain.Responses;
using Microsoft.Extensions.DependencyInjection;

namespace Cycle.Core.Application;

public static class ApplicationDependencyInjectionLayer
{
    public static void AddApplicationLayer(this IServiceCollection services)
    {
        // Command Handlers
        services.AddTransient<ICommandHandler<ProductCommands.CreateProduct, Product>, CreateProductHandler>();
        services.AddTransient<ICommandHandler<ProductCommands.UpdateProduct, Product>, UpdateProductHandler>();
        services.AddTransient<ICommandHandler<ProductCommands.DeleteProduct, Product>, DeleteProductHandler>();

        // Query Handlers
        services.AddTransient<IQueryHandler<ProductQueries.GetProductById, ApiResult<Product>>, GetProductByIdHandler>();
        services.AddTransient<IQueryHandler<ProductQueries.GetAllProducts, ApiResult<PagedResponse<Product>>>, GetAllProductsHandler>();
    }
}
