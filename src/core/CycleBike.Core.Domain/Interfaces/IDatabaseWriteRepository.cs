using CycleBike.Core.Domain.Aggregates;

namespace CycleBike.Core.Domain.Interfaces;

public interface IDatabaseWriteRepository<T> where T : AggregateRoot
{
    Task<int> CommitAsync();
    Task AddAsync(T entity);
    Task AddRangeAsync(IEnumerable<T> entities);
    void Update(T entity);
    void UpdateRange(IEnumerable<T> entities);
    Task<bool> DeleteAsync(T entity);
}