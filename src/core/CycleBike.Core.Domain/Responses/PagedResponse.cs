namespace CycleBike.Core.Domain.Responses;

public record PagedResponse<T>(
    IEnumerable<T> Items,
    int TotalItems,
    int PageNumber,
    int PageSize);
