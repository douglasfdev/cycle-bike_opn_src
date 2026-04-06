using System.Linq.Expressions;
using CycleBike.Adapters.Infrastructure.Modules.Pgsql.Context;
using CycleBike.Core.Domain.Interfaces;
using CycleBike.Core.Domain.Responses;
using Microsoft.EntityFrameworkCore;

namespace CycleBike.Adapters.Infrastructure.Repositories;

public sealed class DatabaseReadRepository<T>(DatabaseReadContext _context): IDatabaseReadRepository<T> where T : class
{
    private readonly DbSet<T> _dbSet = _context.Set<T>();
    
    public IQueryable<T> GetQueryable()
    {
        return _dbSet.AsNoTracking();
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _dbSet.AsNoTracking().ToListAsync();
    }

    public async Task<T?> GetByIdAsync(Ulid id)
    {
        return await _dbSet.FindAsync(id);
    }

    public async Task<PagedResponse<T>> GetPagedAsync( int pageNumber = 1, int pageSize = 10, IQueryable<T>? query = null)
    {
        query = query ?? _dbSet.AsNoTracking();
        
        var totalItems = await query.CountAsync();
        var items = await query
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return new PagedResponse<T>(items, totalItems, pageNumber, pageSize);
    }

    public async Task<T?> GetByPredicateAsync(Expression<Func<T, bool>> predicate)
    {
        return await _dbSet.FirstOrDefaultAsync(predicate);
    }
}