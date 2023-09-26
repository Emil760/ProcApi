using ProcApi.Domain.Models;

namespace ProcApi.Presentation.Handlers.Exception
{
    public interface IExceptionHandler
    {
        public ExceptionModel Handle(System.Exception exception);
    }
}
