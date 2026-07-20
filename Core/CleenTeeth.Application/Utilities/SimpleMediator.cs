using CleenTeeth.Application.Exceptions;

namespace CleenTeeth.Application.Utilities;

public class SimpleMediator(IServiceProvider serviceProvider) : IMediator
{
    public async Task<TResponse> Send<TResponse>(IRequest<TResponse> request)
    {
        var handlerType = typeof(IRequestHandler<,>).MakeGenericType(request.GetType(), typeof(TResponse));
        var handler = serviceProvider.GetService(handlerType)
                        ?? throw new MediatorException($"Handler was not found for {request.GetType().Name}");

        var method = handlerType.GetMethod("Handle")!;
        return await(Task<TResponse>)method.Invoke(handler, [request])!;
    }
}
