using Cycle.Core.Application.Responses;
using CycleBike.Core.Domain.Modules.Entities;

namespace CycleBike.Adapters.GraphQL.Types;

public class ApiResultType<TDataType, T> : ObjectType<ApiResult<T>> where TDataType : ObjectType<T>
{
    protected override void Configure(IObjectTypeDescriptor<ApiResult<T>> descriptor)
    {
        descriptor.Name($"ApiResult_{typeof(T).Name}");

        descriptor.Field(f => f.IsSuccess).Type<NonNullType<BooleanType>>().Description("Indica se a operação foi bem-sucedida");
        descriptor.Field(f => f.Data).Type<TDataType>().Description("Dados retornados");
        descriptor.Field(f => f.Message).Type<StringType>().Description("Mensagem da operação");
        descriptor.Field(f => f.Errors).Type<ListType<StringType>>().Description("Lista de erros");
        descriptor.Field(f => f.StatusCode).Type<IntType>().Description("Código HTTP de status");
    }
}

public class ProductApiResultType : ApiResultType<ProductType, Product>;
