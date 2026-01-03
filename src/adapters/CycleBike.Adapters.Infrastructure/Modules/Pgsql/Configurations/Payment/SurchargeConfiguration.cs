using CycleBike.Core.Domain.Modules.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CycleBike.Adapters.Infrastructure.Modules.Pgsql.Configurations.Payment;

public class SurchargeConfiguration : IEntityTypeConfiguration<Surcharge>
{
    public void Configure(EntityTypeBuilder<Surcharge> builder)
    {
        throw new NotImplementedException();
    }
}