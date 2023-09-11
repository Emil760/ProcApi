using ProcApi.Handlers.Exceptions;

namespace ProcApi.Handlers.Exception
{
    public class NotFoundExceptionHandler : IExceptionHandler
    {
        public void Handle()
        {
            throw new NotImplementedException();
        }
    }
}
