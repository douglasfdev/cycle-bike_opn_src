using CycleBike.Core.Domain.Requests;

namespace CycleBike.Adapters.GraphQL.Types;

public class ProductSearchRequestInputType : InputObjectType<ProductRequest.ProductSearchRequest>
{
    protected override void Configure(IInputObjectTypeDescriptor<ProductRequest.ProductSearchRequest> descriptor)
    {
        descriptor.Name("ProductSearchRequestInput");

        descriptor.Field(f => f.Name).Type<StringType>().Description("Filtrar por nome do produto");
        descriptor.Field(f => f.MinPrice).Type<DecimalType>().Description("Preço mínimo");
        descriptor.Field(f => f.MaxPrice).Type<DecimalType>().Description("Preço máximo");
    }
}
