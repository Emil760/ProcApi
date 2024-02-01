using System.Net.Mime;
using Newtonsoft.Json;
using ProcApi.Domain.Exceptions;
using ProcApi.Domain.Models;

namespace ProcApi.Presentation.Handlers.Exception;

public class MultipleExceptionHandler : IExceptionHandler
{
    public ExceptionModel Handle(System.Exception exception)
    {
        var errors = ((MultipleException)exception).Errors;
        var json = JsonConvert.SerializeObject(errors);

        return new ExceptionModel()
        {
            ContentType = MediaTypeNames.Application.Json,
            StatusCode = 400,
            Message = json
        };
    }
}