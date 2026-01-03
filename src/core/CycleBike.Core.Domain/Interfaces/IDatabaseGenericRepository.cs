namespace CycleBike.Core.Domain.Interfaces;

public interface IDatabaseGenericRepository<T> : IDatabaseReadRepository<T>, IDatabaseWriteRepository<T> 
    where T : class { }