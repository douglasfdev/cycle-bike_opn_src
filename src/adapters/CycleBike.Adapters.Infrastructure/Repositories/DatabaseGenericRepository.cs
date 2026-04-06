using System.Linq.Expressions;
using CycleBike.Adapters.Infrastructure.Modules.Pgsql.Context;
using CycleBike.Core.Domain.Interfaces;
using CycleBike.Core.Domain.Modules;
using CycleBike.Core.Domain.Responses;
using Microsoft.EntityFrameworkCore;

namespace CycleBike.Adapters.Infrastructure.Repositories;

public class DatabaseGenericRepository<T>(
    DatabaseReadContext readContext, 
    DatabaseWriteContext writeContext) : IDatabaseGenericRepository<T> where T : class
{
    private readonly DbSet<T> _readSet = readContext.Set<T>();
    private readonly DbSet<T> _writeSet = writeContext.Set<T>();

    public IQueryable<T> GetQueryable()
    {
        return _readSet.AsNoTracking();
    }

    public async Task<IEnumerable<T>> GetAllAsync() => 
        await _readSet.AsNoTracking().ToListAsync();

    public async Task<T?> GetByIdAsync(Ulid id) => 
        await _readSet.FindAsync(id);

    public async Task<PagedResponse<T>> GetPagedAsync(int pageNumber = 1, int pageSize = 10, IQueryable<T>? query = null)
    {
        query = query ?? _readSet.AsNoTracking();
        
        var totalItems = await query.CountAsync();
        var items = await query
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return new PagedResponse<T>(items, totalItems, pageNumber, pageSize);
    }

    public async Task<T?> GetByPredicateAsync(Expression<Func<T, bool>> predicate) => 
        await _readSet.AsNoTracking().FirstOrDefaultAsync(predicate);

    public async Task<PagedResponse<T>> GetPagedAsync(Expression<Func<T, bool>>? filter = null, int pageNumber = 1, int pageSize = 10)
    {
        IQueryable<T> query = _readSet.AsNoTracking();
        if (filter != null) query = query.Where(filter);

        var items = await query.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
        var totalItems = await query.CountAsync();

        return new PagedResponse<T>(items, totalItems, pageNumber, pageSize);
    }

    public async Task AddAsync(T entity) => await _writeSet.AddAsync(entity);

    public void Update(T entity) => _writeSet.Update(entity);

    public void UpdateRange(IEnumerable<T> entities) => _writeSet.UpdateRange(entities);

    public async Task<int> CommitAsync()
    {
        try
        {
            return await writeContext.SaveChangesAsync();
        }
        catch (DbUpdateException ex)
        {
            throw new Exception("Falha na persistência de dados.", ex);
        }
    }
}