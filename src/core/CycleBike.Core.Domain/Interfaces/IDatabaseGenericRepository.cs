using CycleBike.Core.Domain.Aggregates;

namespace CycleBike.Core.Domain.Interfaces;

public interface IDatabaseGenericRepository<T> : IDatabaseReadRepository<T>, IDatabaseWriteRepository<T> 
    where T : AggregateRoot { }