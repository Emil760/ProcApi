using ProcApi.DTOs.Exception;
using ProcApi.Exceptions;

namespace ProcApi.Handlers.Exception;

public class ExceptionHandlerCoordinator
{
    private readonly Dictionary<Type, IExceptionHandler> _handlers = new();

    public ExceptionHandlerCoordinator(GeneralExceptionHandler generalExceptionHandler,
        NotFoundExceptionHandler notFoundExceptionHandler,
        ValidationExceptionHandler validationExceptionHandler,
        UnauthorizedExceptionHandler unauthorizedExceptionHandler)
    {
        _handlers[typeof(System.Exception)] = generalExceptionHandler;
        _handlers[typeof(NotFoundException)] = notFoundExceptionHandler;
        _handlers[typeof(ValidationExceptionHandler)] = validationExceptionHandler;
        _handlers[typeof(UnauthorizedExceptionHandler)] = unauthorizedExceptionHandler;
    }

    public ExceptionResultDto Handle(System.Exception exception)
    {
        return _handlers[exception.GetType()].Handle(exception);
    }
}