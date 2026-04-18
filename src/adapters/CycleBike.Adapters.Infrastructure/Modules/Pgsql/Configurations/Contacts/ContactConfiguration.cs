using CycleBike.Core.Domain.Modules.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CycleBike.Adapters.Infrastructure.Modules.Pgsql.Configurations.Contacts;

public class ContactConfiguration : AggregateRootConfiguration<Contact>
{
    public override void Configure(EntityTypeBuilder<Contact> builder)
    {
        base.Configure(builder);

        builder.ToTable("contacts");

        builder.Property(x => x.Email)
            .IsRequired()
            .HasMaxLength(50);
        
        builder.HasOne(x => x.Address)
            .WithOne()
            .HasForeignKey<Address>(a => a.ContactId)
            .IsRequired();
    }
}