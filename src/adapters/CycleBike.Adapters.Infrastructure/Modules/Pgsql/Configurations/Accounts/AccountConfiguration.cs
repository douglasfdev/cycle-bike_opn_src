using CycleBike.Core.Domain.Modules.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CycleBike.Adapters.Infrastructure.Modules.Pgsql.Configurations.Accounts;

public class AccountConfiguration : AggregateRootConfiguration<Account>
{
    public override void Configure(EntityTypeBuilder<Account> builder)
    {
        base.Configure(builder);

        builder.ToTable("accounts");
        
        builder
            .HasOne(x => x.Profile)
            .WithOne()
            .HasForeignKey<Profile>(x => x.AccountId)
            .IsRequired();
    }
}