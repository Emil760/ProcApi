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
        UnauthorizedExceptionHandler unauthorizedExceptionHandler)
    {
        _generalExceptionHandler = generalExceptionHandler;
        
        _handlers[typeof(System.Exception)] = generalExceptionHandler;
        _handlers[typeof(NotFoundException)] = notFoundExceptionHandler;
        _handlers[typeof(ValidationException)] = validationExceptionHandler;
        _handlers[typeof(UnauthorizedException)] = unauthorizedExceptionHandler;
    }

    public ExceptionModel Handle(System.Exception exception)
    {
        if (_handlers.TryGetValue(exception.GetType(), out var handler))
            return _handlers[exception.GetType()].Handle(exception);
        return _generalExceptionHandler.Handle(exception);
    }
}