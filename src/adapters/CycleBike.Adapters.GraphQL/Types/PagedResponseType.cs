using CycleBike.Core.Domain.Modules.Entities;
using CycleBike.Core.Domain.Responses;

namespace CycleBike.Adapters.GraphQL.Types;

public class PagedResponseType<TType, T> : ObjectType<PagedResponse<T>> where TType : ObjectType<T>
{
    protected override void Configure(IObjectTypeDescriptor<PagedResponse<T>> descriptor)
    {
        descriptor.Name($"PagedResponse_{typeof(T).Name}");

        descriptor.Field(f => f.Items).Type<NonNullType<ListType<NonNullType<TType>>>>().Description("Lista de itens");
        descriptor.Field(f => f.TotalItems).Type<IntType>().Description("Total de itens");
        descriptor.Field(f => f.PageNumber).Type<IntType>().Description("Número da página");
        descriptor.Field(f => f.PageSize).Type<IntType>().Description("Tamanho da página");
    }
}

public class PagedProductResponseType : PagedResponseType<ProductType, Product>;
