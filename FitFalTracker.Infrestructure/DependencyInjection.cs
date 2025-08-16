using FitFalTracker.Application.Common.Interfaces;
using FitFalTracker.Infrestructure.FileStore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace FitFalTracker.Infrestructure;

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