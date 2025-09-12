using MediatR.Pipeline;
using Microsoft.Extensions.Logging;

namespace FitFalTracker.Application.Common.Behaviours;

public class LoggingBehaviours<TRequest> : IRequestPreProcessor<TRequest>
{
    private readonly ILogger _logger;

    public LoggingBehaviours(ILogger<TRequest> logger)
    {
        _logger = logger;
    }


    public async Task Process(TRequest request, CancellationToken cancellationToken)
    {
        var reqestName = typeof(TRequest).Name; //pobieramy nazwe requestu
        _logger.LogInformation("FitFalTracker Request: {Name} {@Request}" , reqestName, request);
    }
}