using Microsoft.EntityFrameworkCore;

namespace CycleBike.Adapters.Infrastructure.Modules.Pgsql.Context;

public class DatabaseWriteContext(DbContextOptions<DatabaseWriteContext> options) : DbContext(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        => configurationBuilder.Properties<string>()
            .AreUnicode(false)
            .HaveMaxLength(1024);
}