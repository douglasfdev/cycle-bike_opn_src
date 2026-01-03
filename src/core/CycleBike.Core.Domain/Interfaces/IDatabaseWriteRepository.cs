namespace CycleBike.Core.Domain.Interfaces;

public interface IDatabaseWriteRepository<T> where T : class
{
    Task<int> CommitAsync();
    Task AddAsync(T entity);
    void Update(T entity);
    void UpdateRange(IEnumerable<T> entities);
}