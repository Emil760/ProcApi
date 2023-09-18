using System.Net.Mime;
using ProcApi.DTOs.Exception;

namespace ProcApi.Handlers.Exception
{
    public class ValidationExceptionHandler : IExceptionHandler
    {
        public ExceptionResultDto Handle(System.Exception exception)
        {
            return new ExceptionResultDto()
            {
                ContentType = MediaTypeNames.Application.Json,
                StatusCode = 400,
                Message = exception.Message
            };
        }
    }
}