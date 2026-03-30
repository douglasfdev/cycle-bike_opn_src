using System.Linq.Expressions;
using CycleBike.Adapters.Infrastructure.Modules.MongoDB.Context;
using CycleBike.Core.Domain.Interfaces;
using MongoDB.Driver;

namespace CycleBike.Adapters.Infrastructure.Repositories;

public class NoSqlRepository<TEntity>(IMongoContext context) : INoSQLRepository<TEntity> where TEntity : class
{
    private IMongoCollection<TEntity> GetCollection()
        => context.Connect().GetCollection<TEntity>(typeof(TEntity).Name);
    
    private bool HasSession => context.Session != null;

    public IQueryable<TEntity> Query(Expression<Func<TEntity, bool>>? filter)
    {
        IQueryable<TEntity> queryable = HasSession 
            ? GetCollection().AsQueryable(context.Session) 
            : GetCollection().AsQueryable();

        if (filter != null)
        {
            queryable = queryable.Where(filter);
        }

        return queryable;
    }

    public async Task<List<TEntity>> GetAllAsync()
    {
        var filter = Builders<TEntity>.Filter.Empty;

        if (HasSession)
        {
            return await GetCollection()
                .Find(context.Session, filter)
                .ToListAsync();
        }

        return await GetCollection()
            .Find(filter)
            .ToListAsync();
    }

    public async Task<TEntity?> GetByIdAsync(string id)
    {
        var filter = Builders<TEntity>.Filter.Eq("_id", id);

        if (HasSession)
        {
            return await GetCollection()
                .Find(context.Session, filter)
                .FirstOrDefaultAsync();
        }

        return await GetCollection()
            .Find(filter)
            .FirstOrDefaultAsync();
    }

    public async Task AddAsync(TEntity entity)
    {
        if (HasSession)
        {
            await GetCollection().InsertOneAsync(context.Session, entity);
        }
        else
        {
            await GetCollection().InsertOneAsync(entity);
        }
    }

    public async Task AddMany(List<TEntity> entity, CancellationToken token)
    {
        if (HasSession)
        {
            await GetCollection().InsertManyAsync(context.Session, entity, cancellationToken: token);
        }
        else
        {
            await GetCollection().InsertManyAsync(entity, cancellationToken: token);
        }
    }

    public async Task UpdateAsync(string id, TEntity entity)
    {
        var filter = Builders<TEntity>.Filter.Eq("_id", id);

        if (HasSession)
        {
            await GetCollection()
                .ReplaceOneAsync(context.Session, filter, entity);
        }
        else
        {
            await GetCollection()
                .ReplaceOneAsync(filter, entity);
        }
    }

    public async Task DeleteAsync(string id)
    {
        var filter = Builders<TEntity>.Filter.Eq("_id", id);

        if (HasSession)
        {
            await GetCollection()
                .DeleteOneAsync(context.Session, filter);
        }
        else
        {
            await GetCollection()
                .DeleteOneAsync(filter);
        }
    }

    public async Task DeleteManyAsync(List<string> ids)
    {
        var filter = Builders<TEntity>.Filter.In("_id", ids);

        if (HasSession)
        {
            await GetCollection()
                .DeleteManyAsync(context.Session, filter);
        }
        else
        {
            await GetCollection()
                .DeleteManyAsync(filter);
        }
    }

    public void Dispose()
    {
        context.Dispose();
    }
}