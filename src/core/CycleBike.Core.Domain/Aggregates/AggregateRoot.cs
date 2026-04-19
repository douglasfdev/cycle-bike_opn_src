using CycleBike.Core.Domain.Modules.Entities.Extensions;

namespace CycleBike.Core.Domain.Aggregates;

public class AggregateRoot(string createdBy): BaseEntity(createdBy), IAggregateRoot
{
}