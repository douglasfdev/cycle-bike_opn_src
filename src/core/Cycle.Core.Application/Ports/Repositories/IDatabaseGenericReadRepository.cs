namespace Cycle.Core.Application.Ports.Repositories;

public interface IDatabaseGenericReadRepository
{
    Task<T> GetByIdAsync<T>(object id) where T : class;
    Task<IEnumerable<T>> GetAllAsync<T>() where T : class;
    Task<IEnumerable<T>> FindAsync<T>(Func<T, bool> predicate) where T : class;
    Task<int> CountAsync<T>() where T : class;
    Task<bool> ExistsAsync<T>(Guid id) where T : class;
    Task<bool> ExistsAsync<T>(int id) where T : class;
    Task<bool> ExistsAsync<T>(string id) where T : class;
    Task<T> GetPagedAsync<T>(int page, int pageSize) where T : class;
    Task<IEnumerable<T>> GetPagedAsync<T>(int page, int pageSize, Func<T, bool> predicate) where T : class;
    Task<IEnumerable<T>> GetPagedAsync<T>(int page, int pageSize, Func<T, bool> predicate, string orderBy, bool ascending = true) where T : class;
}