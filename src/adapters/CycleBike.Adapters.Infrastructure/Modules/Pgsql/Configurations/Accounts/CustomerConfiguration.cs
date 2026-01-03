using CycleBike.Core.Domain.Modules.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CycleBike.Adapters.Infrastructure.Modules.Pgsql.Configurations.Accounts;

public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.ToTable(nameof(Customer));

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(150);
        
        builder.Property(x => x.Email)
            .IsRequired()
            .HasMaxLength(150);
        
        builder.Property(x => x.Document)
            .IsRequired()
            .HasMaxLength(150);

        builder.Property(x => x.DocumentType)
            .HasDefaultValue("CPF")
            .IsRequired()
            .HasMaxLength(10);
        
        builder.HasOne<Profile>()
            .WithOne(p => p.Customer)
            .HasForeignKey<Customer>(c => c.Id)
            .OnDelete(DeleteBehavior.Cascade);
    }
}