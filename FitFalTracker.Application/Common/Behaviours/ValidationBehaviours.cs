using FluentValidation;
using MediatR;

namespace FitFalTracker.Application.Common.Behaviours;

public class ValidationBehaviours<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public ValidationBehaviours(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var context = new ValidationContext<TRequest>(request);
        var failures = _validators.Select(v=>v.Validate(context))
            .SelectMany(result=>result.Errors)
            .Where(error => error != null)
            .ToList();

        if (failures.Any())
        {
            throw new Exception();
        }

        return await next();
    }
}