using CycleBike.Core.Domain.Modules.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CycleBike.Adapters.Infrastructure.Modules.Pgsql.Configurations.Payment;

public class PaymentMethodConfiguration : AggregateRootConfiguration<PaymentMethod>
{
    public override void Configure(EntityTypeBuilder<PaymentMethod> builder)
    {
        base.Configure(builder);

        builder.ToTable("payment_methods");

        builder
            .Property(x => x.ProfileId)
            .IsRequired();
        
        builder
            .Property(x => x.PaymentType)
            .IsRequired()
            .HasMaxLength(50);
        
        builder
            .Property(x => x.CardId)
            .IsRequired();
        
        builder
            .HasOne(x => x.Card)
            .WithOne()
            .HasForeignKey<PaymentMethod>(x => x.CardId);
    }
}