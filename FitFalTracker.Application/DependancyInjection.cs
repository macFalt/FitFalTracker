using System.Reflection;
using FitFalTracker.Application.Common.Behaviours;
using FitFalTracker.Application.Common.Interfaces;
using FluentValidation;
using MediatR;
using MediatR.Pipeline;
using Microsoft.Extensions.DependencyInjection;

namespace FitFalTracker.Application;

public static class DependancyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(Assembly.GetExecutingAssembly());
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddTransient(typeof(IRequestPreProcessor<>), typeof(LoggingBehaviours<>));
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviours<,>));
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        return services;
    }
}