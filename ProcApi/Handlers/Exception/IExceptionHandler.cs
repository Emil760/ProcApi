using ProcApi.DTOs.Exception;

namespace ProcApi.Handlers.Exception
{
    public interface IExceptionHandler
    {
        public ExceptionResultDto Handle(System.Exception exception);
    }
}
