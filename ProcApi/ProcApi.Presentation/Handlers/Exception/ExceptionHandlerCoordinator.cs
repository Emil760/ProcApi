using ProcApi.Domain.Exceptions;
using ProcApi.Domain.Models;

namespace ProcApi.Presentation.Handlers.Exception;

public class ExceptionHandlerCoordinator
{
    private readonly Dictionary<Type, IExceptionHandler> _handlers = new();
    private readonly GeneralExceptionHandler _generalExceptionHandler;

    public ExceptionHandlerCoordinator(GeneralExceptionHandler generalExceptionHandler,
        NotFoundExceptionHandler notFoundExceptionHandler,
        ValidationExceptionHandler validationExceptionHandler,
        UnauthorizedExceptionHandler unauthorizedExceptionHandler,
        MultipleExceptionHandler multipleExceptionHandler,
        ItemsExceptionHandler itemsExceptionHandler)
    {
        _generalExceptionHandler = generalExceptionHandler;

        _handlers[typeof(System.Exception)] = generalExceptionHandler;
        _handlers[typeof(NotFoundException)] = notFoundExceptionHandler;
        _handlers[typeof(ValidationException)] = validationExceptionHandler;
        _handlers[typeof(UnauthorizedException)] = unauthorizedExceptionHandler;
        _handlers[typeof(MultipleException)] = multipleExceptionHandler;
        _handlers[typeof(ItemsException<int>)] = itemsExceptionHandler;
        _handlers[typeof(ItemsException<Guid>)] = itemsExceptionHandler;
    }

    public ExceptionModel Handle(System.Exception exception)
    {
        if (_handlers.TryGetValue(exception.GetType(), out var handler))
            return handler.Handle(exception);
        return _generalExceptionHandler.Handle(exception);
    }
}