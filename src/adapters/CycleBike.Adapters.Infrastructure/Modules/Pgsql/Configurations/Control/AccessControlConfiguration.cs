using CycleBike.Core.Domain.Modules.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CycleBike.Adapters.Infrastructure.Modules.Pgsql.Configurations.Control;

public class AccessControlConfiguration : AggregateRootConfiguration<AccessControl>
{
    public override void Configure(EntityTypeBuilder<AccessControl> builder)
    {
        base.Configure(builder);

        builder.ToTable("accesscontrols");

        builder
            .Property(x => x.UserId)
            .IsRequired()
            .HasMaxLength(36);

        builder
            .Property(x => x.Role)
            .IsRequired()
            .HasMaxLength(10);

        builder
            .Property(x => x.IsActive)
            .HasDefaultValue(true);

        builder
            .Property(x => x.LastAccess)
            .IsRequired();

        builder.HasOne<User>()
            .WithMany(u => u.AccessControls)
            .HasForeignKey(x => x.UserId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);
    }
}