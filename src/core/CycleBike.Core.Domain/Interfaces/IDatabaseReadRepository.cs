using System.Linq.Expressions;
using CycleBike.Core.Domain.Modules;
using CycleBike.Core.Domain.Responses;

namespace CycleBike.Core.Domain.Interfaces;

public interface IDatabaseReadRepository<T> where T : class
{
    Task<IEnumerable<T>> GetAllAsync();
    Task<T?> GetByIdAsync(Ulid id);
    Task<PagedResponse<T>> GetPagedAsync(
        int pageNumber = 1,
        int pageSize = 10,
        Expression<Func<T, bool>>? filter = null,
        Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null);
    Task<T?> GetByPredicateAsync(Expression<Func<T, bool>> predicate);
}