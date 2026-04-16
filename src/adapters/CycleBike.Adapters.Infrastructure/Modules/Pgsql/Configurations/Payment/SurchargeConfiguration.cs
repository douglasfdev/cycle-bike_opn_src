using CycleBike.Core.Domain.Modules.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CycleBike.Adapters.Infrastructure.Modules.Pgsql.Configurations.Payment;

public class SurchargeConfiguration : AggregateRootConfiguration<Surcharge>
{
    public override void Configure(EntityTypeBuilder<Surcharge> builder)
    {
        base.Configure(builder);

        builder.ToTable("surcharges");
        
        builder
            .Property(x => x.Fee)
            .IsRequired();
    }
}