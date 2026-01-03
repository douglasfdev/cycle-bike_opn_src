using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CycleBike.Adapters.Infrastructure.Modules.Pgsql.Configurations.Payment;

public class PaymentConfiguration : IEntityTypeConfiguration<Core.Domain.Modules.Entities.Payment>
{
    public void Configure(EntityTypeBuilder<Core.Domain.Modules.Entities.Payment> builder)
    {
        throw new NotImplementedException();
    }
}