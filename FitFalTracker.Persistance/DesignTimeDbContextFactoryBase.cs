using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace FitFalTracker.Persistance;

public abstract class DesignTimeDbContextFactoryBase<TContext> 
    : IDesignTimeDbContextFactory<TContext> where TContext : DbContext
{
    private const string ConnectionStringName = "FFTDatabase";
    private const string AspNetEnvironment = "ASPNETCORE_ENVIRONMENT";

    public TContext CreateDbContext(string[] args)
    {
        // katalog projektu API (sąsiad Persistance)
        var basePath = Path.GetFullPath(
            Path.Combine(Directory.GetCurrentDirectory(), "..", "FitFalTracker.Api")
        );

        var environment = Environment.GetEnvironmentVariable(AspNetEnvironment);
        return Create(basePath, environment);
    }

    protected abstract TContext CreateNewInstance(DbContextOptions<TContext> options);

    private TContext Create(string basePath, string? environmentName)
    {
        var cb = new ConfigurationBuilder()
            .SetBasePath(basePath)
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddJsonFile("appsettings.Local.json", optional: true)
            .AddEnvironmentVariables();

        if (!string.IsNullOrWhiteSpace(environmentName))
        {
            cb.AddJsonFile($"appsettings.{environmentName}.json", optional: true);
        }

        var configuration = cb.Build();
        var connectionString = configuration.GetConnectionString(ConnectionStringName);

        if (string.IsNullOrWhiteSpace(connectionString))
            throw new InvalidOperationException($"Brak ConnectionStrings:{ConnectionStringName} w plikach konfiguracyjnych pod {basePath}.");

        var optionsBuilder = new DbContextOptionsBuilder<TContext>()
            .UseSqlServer(connectionString);

        return CreateNewInstance(optionsBuilder.Options);
    }
}