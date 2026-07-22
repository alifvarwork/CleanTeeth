using CleenTeeth.Application.Exceptions;
using FluentValidation;
using FluentValidation.Results;

namespace CleenTeeth.Application.Utilities;

public class SimpleMediator(IServiceProvider serviceProvider) : IMediator
{
    public async Task<TResponse> Send<TResponse>(IRequest<TResponse> request)
    {
        await ValidateRequest(request);
        return await HandleRequest(request);
    }

    private async Task<TResponse> HandleRequest<TResponse>(IRequest<TResponse> request)
    {
        var handlerType = typeof(IRequestHandler<,>).MakeGenericType(request.GetType(), typeof(TResponse));
        var handler = serviceProvider.GetService(handlerType)
                        ?? throw new MediatorException($"Handler was not found for {request.GetType().Name}");

        var method = handlerType.GetMethod("Handle")!;
        return await (Task<TResponse>)method.Invoke(handler, [request])!;
    }

    private async Task ValidateRequest<TResponse>(IRequest<TResponse> request)
    {
        var validatorType = typeof(IValidator<>).MakeGenericType(request.GetType());
        var validator = serviceProvider.GetService(validatorType);

        if (validator is not null)
        {
            var validateMethod = validatorType.GetMethod(nameof(IValidator<>.ValidateAsync));
            var taskToValidate = (Task)validateMethod!.Invoke(validator, [request, CancellationToken.None])!;

            await taskToValidate;

            var result = taskToValidate.GetType().GetProperty("Result");
            var validationResult = (ValidationResult)result!.GetValue(taskToValidate)!;

            if (!validationResult.IsValid)
            {
                throw new CustomValidationException(validationResult);
            }
        }
    }
}
