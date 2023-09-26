using System.Net.Mime;
using ProcApi.Domain.Models;

namespace ProcApi.Presentation.Handlers.Exception;

public class UnauthorizedExceptionHandler : IExceptionHandler
{
    public ExceptionModel Handle(System.Exception exception)
    {
        return new ExceptionModel
        {
            ContentType = MediaTypeNames.Text.Plain,
            StatusCode = 401,
            Message = exception.Message
        };
    }
}