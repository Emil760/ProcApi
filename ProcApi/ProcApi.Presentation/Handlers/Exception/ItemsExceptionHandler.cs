using ProcApi.Domain.Models;

namespace ProcApi.Presentation.Handlers.Exception;

public class ItemsExceptionHandler : IExceptionHandler
{
    public ExceptionModel Handle(System.Exception exception)
    {
        throw new NotImplementedException();
    }
}