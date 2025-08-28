using FitFalTracker.Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FitFalTracker.Persistance;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistance(this IServiceCollection services, IConfiguration configuration) //to extension method. Rozszerza IServiceCollection o  własną metodę AddPersistence, żeby konfiguracja DI była zgrabna i łatwa do wywołania w Program.cs.
    {
        services.AddDbContext<FitFalDbContext>(options=>options.UseSqlServer(configuration.GetConnectionString("FFTDatabase")));
        
        services.AddScoped<IFitFalDbContext,FitFalDbContext>();
        
        return services;
    }
}