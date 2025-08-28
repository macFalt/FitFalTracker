using System.Reflection;
using FitFalTracker.Application.Common.Interfaces;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace FitFalTracker.Application;

public static class DependancyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(Assembly.GetExecutingAssembly());
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        return services;
    }
}