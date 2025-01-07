using FluentValidation;
using MediatR;

namespace Application.Shared.Behavior;

public class ValidationBehavior<TRequest, TResponse>(IValidator<TRequest> validator)
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse>
        next, CancellationToken cancellationToken)
    {
        // Verifique se a solicitação não requer validação
        if (validator is null)
        {
            return await next();
        }

        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.Errors);
        }
        return await next();
    }
}