using CycleBike.Core.Domain.Modules.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CycleBike.Adapters.Infrastructure.Modules.Pgsql.Configurations.Control;

public class TrialConfiguration : AggregateRootConfiguration<Trial>
{
    public override void Configure(EntityTypeBuilder<Trial> builder)
    {
        base.Configure(builder);

        builder.ToTable("trials");

        builder
            .Property(x => x.UserId)
            .IsRequired()
            .HasMaxLength(20);
        
        builder
            .Property(x => x.TrialStartDate)
            .IsRequired()
            .HasMaxLength(40);
        
        builder
            .Property(x => x.TrialEndDate)
            .IsRequired()
            .HasMaxLength(40);
        
        builder
            .Property(x => x.IsActive)
            .HasDefaultValue(true);
        
        builder
            .Property(x => x.TrialDays)
            .IsRequired()
            .HasMaxLength(3);

        builder.HasOne<User>()
            .WithMany(u => u.Trials)
            .HasForeignKey(x => x.UserId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);
    }
}