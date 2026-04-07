using Cycle.Core.Application.Abstractions.Contracts;
using CycleBike.Core.Domain.Requests;

namespace Cycle.Core.Application.Schemas.Queries;

public abstract class ProductQueries
{
    public record GetProductById(Ulid Id) : IQuery;
    public record GetAllProducts(int Page, int PageSize, ProductRequest.ProductSearchRequest Filters) : IQuery;
    public record GetPendingMessages() : IQuery;
    public record GetPendingMessage(string Id) : IQuery;
}
