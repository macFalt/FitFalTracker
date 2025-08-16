using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FitFalTracker.Persistance;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistance(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<FitFalDbContext>(options=>options.UseSqlServer(configuration.GetConnectionString("FFTDatabase")));
        return services;
    }
}