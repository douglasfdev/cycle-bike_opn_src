using Cycle.Core.Application.Modules.Product;
using Cycle.Core.Application.Ports.Handlers;
using Cycle.Core.Application.Schemas.Commands;
using Cycle.Core.Application.Schemas.Queries;
using CycleBike.Core.Domain.Modules.Entities;
using CycleBike.Core.Domain.Modules.Events.Envelopes;
using CycleBike.Core.Domain.Responses;
using Microsoft.Extensions.DependencyInjection;

namespace Cycle.Core.Application;

public static class ApplicationDependencyInjectionLayer
{
    public static void AddApplicationLayer(this IServiceCollection services)
    {
        #region Command Handlers
        
        services.AddTransient<ICommandHandler<ProductCommands.CreateProduct, Product>, CreateProductHandler>();
        services.AddTransient<ICommandHandler<ProductCommands.UpdateProduct, Product>, UpdateProductHandler>();
        services.AddTransient<ICommandHandler<ProductCommands.DeleteProduct, Product>, DeleteProductHandler>();
        services.AddTransient<ICommandHandler<ProductCommands.PublishProduct, object>, PublishProductHandler>();
        services.AddTransient<ICommandHandler<ProductCommands.CreateCachedProduct, Product>, CreateProductCacheHandler>();

        #endregion

        #region Query Handlers

        services.AddTransient<IQueryHandler<ProductQueries.GetProductById, Product>, GetProductByIdHandler>();
        services.AddTransient<IQueryHandler<ProductQueries.GetAllProducts, PagedResponse<Product>>, GetAllProductsHandler>();
        services.AddTransient<IQueryHandler<ProductQueries.GetPendingMessages, List<OutboxEnvelope?>>, GetPendingMessagesHandler>();
        services.AddTransient<IQueryHandler<ProductQueries.GetPendingMessage, OutboxEnvelope?>, GetPendingMessageHandler>();

        #endregion
    }
}
