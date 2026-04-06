using System.Linq.Expressions;
using CycleBike.Core.Domain.Modules;
using CycleBike.Core.Domain.Responses;

namespace CycleBike.Core.Domain.Interfaces;

public interface IDatabaseReadRepository<T> where T : class
{
    IQueryable<T> GetQueryable();
    Task<IEnumerable<T>> GetAllAsync();
    Task<T?> GetByIdAsync(Ulid id);
    Task<PagedResponse<T>> GetPagedAsync(int pageNumber = 1, int pageSize = 10, IQueryable<T>? query = null);
    Task<T?> GetByPredicateAsync(Expression<Func<T, bool>> predicate);
}