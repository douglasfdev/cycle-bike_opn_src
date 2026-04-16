using CycleBike.Core.Domain.Modules.Entities;

namespace CycleBike.Adapters.GraphQL.Types;

public class ProductType : ObjectType<Product>
{
    protected override void Configure(IObjectTypeDescriptor<Product> descriptor)
    {
        descriptor.Name("Product");

        descriptor.Field(f => f.Id).Type<NonNullType<StringType>>().Description("Identificador único do produto");
        descriptor.Field(f => f.Name).Type<StringType>().Description("Nome do produto");
        descriptor.Field(f => f.Price).Type<DecimalType>().Description("Preço do produto");
        descriptor.Field(f => f.Description).Type<StringType>().Description("Descrição do produto");
        descriptor.Field(f => f.IsDeleted).Type<BooleanType>().Description("Indica se o produto foi deletado");
        descriptor.Field(f => f.CreatedAt).Type<DateTimeType>().Description("Data de criação");
        descriptor.Field(f => f.UpdatedAt).Type<DateTimeType>().Description("Data de atualização");
    }
}
