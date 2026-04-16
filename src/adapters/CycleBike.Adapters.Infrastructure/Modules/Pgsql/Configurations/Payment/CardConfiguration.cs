using CycleBike.Core.Domain.Modules.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CycleBike.Adapters.Infrastructure.Modules.Pgsql.Configurations.Payment;

public class CardConfiguration : AggregateRootConfiguration<Card>
{
    public override void Configure(EntityTypeBuilder<Card> builder)
    {
        base.Configure(builder);

        builder.ToTable("cards");
        
        builder.Property(x => x.Number)
            .IsRequired()
            .HasMaxLength(16);
        
        builder.Property(x => x.Type)
            .IsRequired()
            .HasMaxLength(50);
        
        builder.Property(x => x.HolderName)
            .IsRequired()
            .HasMaxLength(150);
        
        builder.Property(x => x.ExpirationDate)
            .IsRequired()
            .HasMaxLength(4);
        
        builder.Property(x => x.Cvv)
            .IsRequired()
            .HasMaxLength(4);
    }
}