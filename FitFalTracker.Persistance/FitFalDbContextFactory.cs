using Microsoft.EntityFrameworkCore;

namespace FitFalTracker.Persistance;

public class FitFalDbContextFactory : DesignTimeDbContextFactoryBase<FitFalDbContext>
{
    protected override FitFalDbContext CreateNewInstance(DbContextOptions<FitFalDbContext> options)
    {
        return new FitFalDbContext(options);
    }
}