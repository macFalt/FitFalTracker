using FitFalTracker.Application.Common.Interfaces;
using FitFalTracker.Infrastructure.FileStore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace FitFalTracker.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrestructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddTransient<IDirectoryWrapper, DirectoryWrapper>();
        services.AddTransient<IFileWrapper, FileWrapper>();
        services.AddTransient<IFileStore, FileStore.FileStore>();
        
        return services;
    }
}