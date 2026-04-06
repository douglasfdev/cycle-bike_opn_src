using CycleBike.Core.Domain.Modules.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CycleBike.Adapters.Infrastructure.Modules.Pgsql.Configurations.Orders;

public class ProductConfiguration : AggregateRootConfiguration<Product>
{
    public override void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(150);

        builder.Property(p => p.Price)
            .IsRequired()
            .HasPrecision(10, 2);

        builder.Property(p => p.Description)
            .IsRequired()
            .HasMaxLength(500);
    }
}