namespace Cycle.Core.Application.Ports.Repositories;

public interface IDatabaseGenericWriteRepository
{
    Task<T> AddAsync<T>(T entity) where T : class;
    Task<T> UpdateAsync<T>(T entity) where T : class;
    Task<bool> DeleteAsync<T>(object id) where T : class;
    Task<bool> SaveChangesAsync();
    Task CommitAsync();
    Task<T> AddRangeAsync<T>(IEnumerable<T> entityList) where T : class;
    Task<T> UpdateRangeAsync<T>(IEnumerable<T> entityList) where T : class;
    Task<bool> DeleteRangeAsync<T>(IEnumerable<T> entities) where T : class;
    Task<bool> ExecuteRawSqlAsync(string sql, params dynamic[] parameters);
}