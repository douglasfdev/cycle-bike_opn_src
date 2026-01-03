using System.Linq.Expressions;
using CycleBike.Core.Domain.Modules;

namespace CycleBike.Core.Domain.Interfaces;

public interface IDatabaseReadRepository<T> where T : class
{
    Task<IEnumerable<T>> GetAllAsync();
    Task<T?> GetByIdAsync(Ulid id);
    Task<PagedResult<T>> GetPagedAsync(
        Expression<Func<T, bool>>? filter = null,
        Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
        int pageNumber = 1,
        int pageSize = 10);
    Task<T?> GetByPredicateAsync(Expression<Func<T, bool>> predicate);
}