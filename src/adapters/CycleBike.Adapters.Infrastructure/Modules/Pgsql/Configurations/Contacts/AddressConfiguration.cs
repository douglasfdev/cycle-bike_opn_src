using CycleBike.Core.Domain.Modules.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CycleBike.Adapters.Infrastructure.Modules.Pgsql.Configurations.Contacts;

public class AddressConfiguration : IEntityTypeConfiguration<Address>
{
    public void Configure(EntityTypeBuilder<Address> builder)
    {
        builder.ToTable(nameof(Address));
        
        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.City)
            .IsRequired()
            .HasMaxLength(100);
        
        builder.Property(x => x.State)
            .IsRequired()
            .HasMaxLength(2);

        builder.Property(x => x.Country)
            .IsRequired()
            .HasDefaultValue("BRL")
            .HasMaxLength(3);
        
        builder.Property(x => x.Street)
            .IsRequired()
            .HasMaxLength(200);
        
        builder.Property(x => x.Number)
            .IsRequired()
            .HasMaxLength(50);
        
        builder.Property(x => x.Complement)
            .HasMaxLength(200);
        
        builder.Property(x => x.Neighborhood)
            .IsRequired()
            .HasMaxLength(100);
        
        builder.Property(x => x.PostalCode)
            .IsRequired()
            .HasMaxLength(10);
    }
}