using CycleBike.Adapters.Infrastructure.Modules.Pgsql.Context;
using CycleBike.Core.Domain.Aggregates;
using CycleBike.Core.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CycleBike.Adapters.Infrastructure.Repositories;

public class DatabaseWriteRepository<T>(DatabaseWriteContext _context) : IDatabaseWriteRepository<T> where T : AggregateRoot
{
    private readonly DbSet<T> _dbSet = _context.Set<T>();

    public async Task<int> CommitAsync()
    {
        try
        {
            return await _context.SaveChangesAsync();
        }
        catch (DbUpdateException ex)
        {
            throw new Exception("Erro ao persistir dados no PostgreSQL.", ex);
        }
    }

    public async Task AddAsync(T entity)
    {
        await _dbSet.AddAsync(entity);
    }

    public async Task AddRangeAsync(IEnumerable<T> entities)
    {
        await _dbSet.AddRangeAsync();
    }

    public void Update(T entity)
    {
        _dbSet.Update(entity);
    }

    public void UpdateRange(IEnumerable<T> entities)
    {
        _dbSet.UpdateRange(entities);
    }

    public async Task<bool> DeleteAsync(T entity)
    {
        entity.IsDeleted = true;
        _dbSet.Update(entity);
        var saved = await _context.SaveChangesAsync();
        return saved > 0;
    }
}