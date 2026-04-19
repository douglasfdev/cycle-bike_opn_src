using CycleBike.Core.Domain.Aggregates;

namespace CycleBike.Core.Domain.Modules.Entities;

public class Surcharge: AggregateRoot
{
    public decimal Fee { get; set; }
    
    public Surcharge() : base(default) {}

    private Surcharge(decimal fee, string createdBy) : base(createdBy)
    {
        Fee = fee;
        CreatedBy = createdBy;
    }

    public static Surcharge Create(decimal fee, string createdBy) => new(fee, createdBy);
}