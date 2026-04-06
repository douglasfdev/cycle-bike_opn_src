namespace CycleBike.Core.Domain.Filters;

public abstract class FilterableService<TEntity, TSearchRequest>
{
    protected abstract IQueryable<TEntity> ApplyFilters(IQueryable<TEntity> query, TSearchRequest filters);
}