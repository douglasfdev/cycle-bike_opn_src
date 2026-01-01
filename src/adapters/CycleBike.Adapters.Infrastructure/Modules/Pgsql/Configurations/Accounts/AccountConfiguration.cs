using CycleBike.Core.Domain.Modules.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CycleBike.Adapters.Infrastructure.Modules.Pgsql.Configurations.Accounts;

public class AccountConfiguration : IEntityTypeConfiguration<Account>
{
    public void Configure(EntityTypeBuilder<Account> builder)
    {
        builder.ToTable(nameof(Account));
        
        builder.HasKey(x => x.Id);
        
        builder
            .HasOne(x => x.Profile)
            .WithOne()
            .HasForeignKey<Profile>(x => x.Id)
            .IsRequired();
        
        builder.OwnsOne(
            profile => profile.Profile,
            profile =>
        {
            profile.ToTable(nameof(Profile));
            profile.Property<string>("Id").IsRequired();
            profile.HasKey("Id");
        });
    }
}