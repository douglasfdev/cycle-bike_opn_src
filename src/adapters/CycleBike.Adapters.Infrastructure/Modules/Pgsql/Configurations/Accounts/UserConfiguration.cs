using CycleBike.Core.Domain.Modules.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CycleBike.Adapters.Infrastructure.Modules.Pgsql.Configurations.Accounts;

public class UserConfiguration : AggregateRootConfiguration<User>
{
    public override void Configure(EntityTypeBuilder<User> builder)
    {
        base.Configure(builder);

        builder.ToTable("users");

        builder
            .Property(x => x.Username)
            .IsRequired()
            .HasMaxLength(100);
        
        builder
            .Property(x => x.Email)
            .IsRequired()
            .HasMaxLength(100);
        
        builder
            .Property(x => x.IsActive)
            .HasDefaultValue(true);
        
        builder
            .Property(x => x.PasswordHash)
            .IsRequired()
            .HasMaxLength(255);

        builder.HasMany(x => x.Trials)
            .WithOne()
            .HasForeignKey("UserId")
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(x => x.AccessControls)
            .WithOne()
            .HasForeignKey("UserId")
            .OnDelete(DeleteBehavior.Cascade);

        builder.Navigation(x => x.Trials)
            .HasField("_trials")
            .UsePropertyAccessMode(PropertyAccessMode.Field);

        builder.Navigation(x => x.AccessControls)
            .HasField("_accessControls")
            .UsePropertyAccessMode(PropertyAccessMode.Field);
    }
}