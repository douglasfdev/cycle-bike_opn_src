using CycleBike.Adapters.GraphQL.ErrorHandling;
using CycleBike.Adapters.GraphQL.Mutations;
using CycleBike.Adapters.GraphQL.Queries;
using CycleBike.Adapters.GraphQL.Scalars;
using CycleBike.Adapters.GraphQL.Subscriptions;
using CycleBike.Adapters.GraphQL.Types;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace CycleBike.Adapters.GraphQL.Configuration;

public static class GraphQLExtensions
{
    public static IServiceCollection AddGraphQLAdapter(this IServiceCollection services)
    {
        services.AddSingleton<ProductTopicEventSender>();

        services
            .AddGraphQLServer()
            .AddQueryType(d => d.Name("Query"))
                .AddTypeExtension<ProductQuery>()
            .AddMutationType(d => d.Name("Mutation"))
                .AddTypeExtension<ProductMutation>()
            .AddSubscriptionType(d => d.Name("Subscription"))
                .AddTypeExtension<ProductSubscription>()
            .AddType<ProductType>()
            .AddType<OutboxEnvelopeType>()
            .AddType<ProductApiResultType>()
            .AddType<PagedProductResponseType>()
            .AddType<CreateProductInputType>()
            .AddType<UpdateProductInputType>()
            .AddType<ProductSearchRequestInputType>()
            .AddType<UlidScalar>()
            .AddInMemorySubscriptions()
            .AddErrorFilter<GraphQLErrorFilter>()
            .ModifyOptions(o =>
            {
                o.SortFieldsByName = true;
            });

        return services;
    }

    public static IApplicationBuilder MapGraphQLAdapter(this IApplicationBuilder app)
    {
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapGraphQL("/graphql");
            endpoints.MapGraphQLSchema("/graphql/schema");
        });

        return app;
    }
}
