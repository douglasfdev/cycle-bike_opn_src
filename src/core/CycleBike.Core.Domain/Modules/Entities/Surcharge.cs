using CycleBike.Core.Domain.Aggregates;

namespace CycleBike.Core.Domain.Modules.Entities;

public class Surcharge: AggregateRoot
{
    public decimal Fee { get; set; }
}