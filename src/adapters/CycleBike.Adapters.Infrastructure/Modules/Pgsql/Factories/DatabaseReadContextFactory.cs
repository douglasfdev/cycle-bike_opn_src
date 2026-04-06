using CycleBike.Adapters.Infrastructure.Modules.Pgsql.Context;
using CycleBike.Core.Common.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace CycleBike.Adapters.Infrastructure.Modules.Pgsql.Factories;

public class DatabaseReadContextFactory: IDesignTimeDbContextFactory<DatabaseReadContext>
{
    public DatabaseReadContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<DatabaseReadContext>();
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

        return new DatabaseReadContext(optionsBuilder.Options);
    }
}