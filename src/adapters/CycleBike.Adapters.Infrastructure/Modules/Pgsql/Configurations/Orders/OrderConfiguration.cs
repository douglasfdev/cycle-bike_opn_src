using CycleBike.Core.Domain.Modules.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CycleBike.Adapters.Infrastructure.Modules.Pgsql.Configurations.Orders;

public class OrderConfiguration : AggregateRootConfiguration<Order>
{
    public override void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.ToTable("orders");

        builder.HasOne(x => x.Customer)
            .WithOne()
            .HasForeignKey<Order>(o => o.CustomerId)
            .IsRequired();
        
        builder.HasOne(x => x.Product)
            .WithOne()
            .HasForeignKey<Order>(o => o.ProductId)
            .IsRequired();
        
        builder.HasOne(x => x.Payment)
            .WithOne()
            .HasForeignKey<Order>(o => o.PaymentId)
            .IsRequired();
        
        builder.Property(x => x.Status)
            .IsRequired()
            .HasMaxLength(20);
    }
}