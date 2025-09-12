using System.Diagnostics;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FitFalTracker.Application.Common.Behaviours;

public class PerformanceBehaviours<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
{
    private readonly ILogger _logger;
    private readonly Stopwatch _timmer;

    public PerformanceBehaviours(ILogger logger, Stopwatch timmer)
    {
        _logger = logger;
        _timmer = timmer;
    }


    public async  Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        _timmer.Start();
        var response = await next();
        _timmer.Stop();
        var elapsed = _timmer.ElapsedMilliseconds;
        if (elapsed > 500)
        {
            var requestName = typeof(TRequest).Name;
            _logger.LogInformation("FitFalTracker Long Running Request: {name} ({elapsed} milliseconds){@Request}", requestName, elapsed, request);
        }

        return response;
    }
}