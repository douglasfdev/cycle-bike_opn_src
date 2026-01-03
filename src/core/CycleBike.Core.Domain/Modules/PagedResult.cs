namespace CycleBike.Core.Domain.Modules;

public record PagedResult<T>(
    IEnumerable<T> items,
    int TotalItems,
    int PageNumber,
    int PageSize)
{
    public int TotalPages => (int)Math.Ceiling(TotalItems/(double)PageSize);
};
