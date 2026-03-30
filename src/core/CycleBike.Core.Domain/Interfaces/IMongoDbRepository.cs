using System.Linq.Expressions;
using MongoDB.Driver;

namespace CycleBike.Core.Domain.Interfaces;

public interface IMongoDbRepository<TEntity> : IDisposable
{
    IQueryable<TEntity> Query(Expression<Func<TEntity, bool>>? filter);
    Task<List<TEntity>> GetAllAsync();
    Task<TEntity?> GetByIdAsync(string id);
    Task AddAsync(TEntity entity);

    Task AddMany(List<TEntity> entity, CancellationToken token);
    Task UpdateAsync(string id, TEntity entity);
    Task DeleteAsync(string id);
    Task DeleteManyAsync(List<string> ids);
}