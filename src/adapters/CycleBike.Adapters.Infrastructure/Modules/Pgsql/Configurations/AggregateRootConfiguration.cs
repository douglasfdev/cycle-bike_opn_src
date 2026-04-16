using CycleBike.Core.Domain.Aggregates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CycleBike.Adapters.Infrastructure.Modules.Pgsql.Configurations;

public abstract class AggregateRootConfiguration<T> : IEntityTypeConfiguration<T> where T : AggregateRoot
{
    public virtual void Configure(EntityTypeBuilder<T> builder)
    {
        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.Id);

        builder.Property(x => x.IsDeleted).IsRequired();
        builder.Property(x => x.CreatedAt).IsRequired();
        builder.Property(x => x.UpdatedAt);
    }
}