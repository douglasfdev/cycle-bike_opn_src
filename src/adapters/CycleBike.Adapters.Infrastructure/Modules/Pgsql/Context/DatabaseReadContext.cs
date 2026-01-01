using Microsoft.EntityFrameworkCore;

namespace CycleBike.Adapters.Infrastructure.Modules.Pgsql.Context;

public class DatabaseReadContext(DbContextOptions<DatabaseReadContext> options) : DbContext(options)
{
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // modelBuilder.Entity<>().HasNoKey().ToView(nameof());
        // modelBuilder.Entity<>().HasNoKey().ToView(nameof());
        // modelBuilder.Entity<>().HasNoKey().ToView(nameof());
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        => configurationBuilder.Properties<string>()
            .AreUnicode(false)
            .HaveMaxLength(1024);
}