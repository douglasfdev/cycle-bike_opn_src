using CycleBike.Core.Domain.Requests;

namespace CycleBike.Adapters.GraphQL.Types;

public class UpdateProductInputType : InputObjectType<ProductRequest.UpdateProduct>
{
    protected override void Configure(IInputObjectTypeDescriptor<ProductRequest.UpdateProduct> descriptor)
    {
        descriptor.Name("UpdateProductInput");

        descriptor.Field(f => f.Id).Type<NonNullType<StringType>>().Description("Identificador único do produto");
        descriptor.Field(f => f.Name).Type<NonNullType<StringType>>().Description("Nome do produto");
        descriptor.Field(f => f.Price).Type<NonNullType<DecimalType>>().Description("Preço do produto");
        descriptor.Field(f => f.Description).Type<NonNullType<StringType>>().Description("Descrição do produto");
    }
}
