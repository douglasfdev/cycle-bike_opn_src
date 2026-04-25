using CycleBike.Core.Domain.Logging;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CycleBike.Adapters.Infrastructure.Modules.Pgsql.Configurations;

public class LoggerConfiguration : AggregateRootConfiguration<LogEntry>
{
    public override void Configure(EntityTypeBuilder<LogEntry> builder)
    {
        base.Configure(builder);

        builder.ToTable("logentry");

        builder.Property(x => x.Timestamp)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(x => x.ApplicationName)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(x => x.Level)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(x => x.Message)
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(x => x.Category)
            .IsRequired()
            .HasMaxLength(25);

        builder.Property(x => x.Exception)
            .IsRequired(false)
            .HasColumnType("text");;

        builder.Property(x => x.Properties)
            .HasColumnType("jsonb")
            .IsRequired();
    }
}