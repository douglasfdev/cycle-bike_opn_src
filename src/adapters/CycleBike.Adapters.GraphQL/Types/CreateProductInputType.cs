using CycleBike.Core.Domain.Requests;

namespace CycleBike.Adapters.GraphQL.Types;

public class CreateProductInputType : InputObjectType<ProductRequest.CreateProduct>
{
    protected override void Configure(IInputObjectTypeDescriptor<ProductRequest.CreateProduct> descriptor)
    {
        descriptor.Name("CreateProductInput");

        descriptor.Field(f => f.Name).Type<NonNullType<StringType>>().Description("Nome do produto");
        descriptor.Field(f => f.Price).Type<NonNullType<DecimalType>>().Description("Preço do produto");
        descriptor.Field(f => f.Description).Type<NonNullType<StringType>>().Description("Descrição do produto");
    }
}
