using CycleBike.Core.Domain.Modules.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CycleBike.Adapters.Infrastructure.Modules.Pgsql.Configurations.Contacts;

public class PhoneConfiguration : AggregateRootConfiguration<Phone>
{
    public override void Configure(EntityTypeBuilder<Phone> builder)
    {
        builder.ToTable("phones");

        builder.Property(x => x.Number)
            .IsRequired()
            .HasMaxLength(20);
        
        builder.Property(x => x.AreaCode)
            .IsRequired()
            .HasMaxLength(5);
        
        builder.Property(x => x.CountryCode)
            .IsRequired()
            .HasDefaultValue("55")
            .HasMaxLength(5);
        
        builder.Property(x => x.Type)
            .IsRequired()
            .HasDefaultValue("Mobile")
            .HasMaxLength(20);
        
        builder.HasOne(x => x.Contact)
            .WithOne()
            .HasForeignKey<Phone>(p => p.ContactId)
            .IsRequired();
    }
}