using CycleBike.Core.Domain.Modules.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CycleBike.Adapters.Infrastructure.Modules.Pgsql.Configurations.Accounts;

public class ProfileConfiguration : AggregateRootConfiguration<Profile>
{
    public override void Configure(EntityTypeBuilder<Profile> builder)
    {
        builder.ToTable("profiles");
        
        builder.HasOne(profile => profile.Customer)
            .WithOne()
            .HasForeignKey<Customer>(customer => customer.Id)
            .IsRequired();

        builder.HasOne(profile => profile.Address)
            .WithOne()
            .HasForeignKey<Address>(address => address.Id)
            .IsRequired();
        
        builder.HasOne(profile => profile.Contact)
            .WithOne()
            .HasForeignKey<Contact>(contact => contact.Id)
            .IsRequired();

        builder.HasMany(profile => profile.PaymentMethods)
            .WithOne()
            .HasForeignKey(paymentMethod => paymentMethod.ProfileId)
            .IsRequired();
    }
}