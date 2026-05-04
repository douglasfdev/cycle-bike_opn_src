using System.Linq.Expressions;
using CycleBike.Adapters.Infrastructure.Modules.Pgsql.Context;
using CycleBike.Core.Domain.Aggregates;
using CycleBike.Core.Domain.Interfaces;
using CycleBike.Core.Domain.Modules;
using CycleBike.Core.Domain.Responses;
using Microsoft.EntityFrameworkCore;

namespace CycleBike.Adapters.Infrastructure.Repositories;

public class DatabaseGenericRepository<T>(
    IDatabaseReadRepository<T> readRepository, 
    IDatabaseWriteRepository<T> writeRepository) : IDatabaseGenericRepository<T> where T : AggregateRoot
{

    public IQueryable<T> GetQueryable() => readRepository.GetQueryable();

    public async Task<IEnumerable<T>> GetAllAsync() => await readRepository.GetAllAsync();

    public async Task<T?> GetByIdAsync(Ulid id) => await readRepository.GetByIdAsync(id);

    public async Task<PagedResponse<T>> GetPagedAsync(int pageNumber = 1, int pageSize = 10, IQueryable<T>? query = null)
        => await readRepository.GetPagedAsync(pageNumber, pageSize, query);

    public async Task<T?> GetByPredicateAsync(Expression<Func<T, bool>> predicate) => 
        await readRepository.GetByPredicateAsync(predicate);

    public async Task AddAsync(T entity) => await writeRepository.AddAsync(entity);
    public async Task AddRangeAsync(IEnumerable<T> entities)
    {
        await writeRepository.AddRangeAsync(entities);
    }

    public void Update(T entity) => writeRepository.Update(entity);

    public void UpdateRange(IEnumerable<T> entities) => writeRepository.UpdateRange(entities);
    public async Task<bool> DeleteAsync(T entity) => await writeRepository.DeleteAsync(entity);

    public async Task<int> CommitAsync() => await writeRepository.CommitAsync();
}