using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CycleBike.Adapters.Infrastructure.Modules.Pgsql.Configurations.Payment;

public class PaymentConfiguration : AggregateRootConfiguration<Core.Domain.Modules.Entities.Payment>
{
    public override void Configure(EntityTypeBuilder<Core.Domain.Modules.Entities.Payment> builder)
    {
        base.Configure(builder);

        builder.ToTable("payments");
        
        builder
            .Property(x => x.OrderId)
            .IsRequired();

        builder
            .HasOne(x => x.PaymentMethod)
            .WithMany()
            .HasForeignKey(x => x.PaymentMethodId);
        
        builder
            .Property(x => x.Amount)
            .IsRequired()
            .HasPrecision(18, 2);
        
        builder
            .Property(x => x.Currency)
            .IsRequired()
            .HasMaxLength(3);

        builder
            .Property(x => x.Status)
            .IsRequired()
            .HasMaxLength(20);
        
        builder
            .Property(x => x.TransactionDetails)
            .HasMaxLength(255);
        
        builder
            .Property(x => x.TransactionId)
            .HasMaxLength(255);
        
        builder
            .Property(x => x.ProcessedAt)
            .IsRequired();
    }
}