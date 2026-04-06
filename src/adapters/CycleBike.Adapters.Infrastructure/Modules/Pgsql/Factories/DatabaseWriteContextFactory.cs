using CycleBike.Adapters.Infrastructure.Modules.Pgsql.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace CycleBike.Adapters.Infrastructure.Modules.Pgsql.Factories;

public class DatabaseWriteContextFactory: IDesignTimeDbContextFactory<DatabaseWriteContext>
{
    public DatabaseWriteContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<DatabaseWriteContext>();
        var connectionString = Environment.GetEnvironmentVariable("ConnectionStrings__DatabaseConnection");

        if (string.IsNullOrEmpty(connectionString))
        {
            var assemblyPath = AppContext.BaseDirectory;
            var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Development";
        
            var configuration = new ConfigurationBuilder()
                .SetBasePath(assemblyPath) // IMPORTANTE: Usar BaseDirectory
                .AddJsonFile("appsettings.json", optional: true)
                .AddJsonFile($"appsettings.{env}.json", optional: true)
                .AddEnvironmentVariables()
                .Build();

            connectionString = configuration.GetConnectionString("DatabaseConnection");
        }

        if (string.IsNullOrEmpty(connectionString))
        {
            throw new InvalidOperationException(
                $"ConnectionString não encontrada em: {AppContext.BaseDirectory}");
        }

        optionsBuilder.UseNpgsql(connectionString);

        return new DatabaseWriteContext(optionsBuilder.Options);
    }
}