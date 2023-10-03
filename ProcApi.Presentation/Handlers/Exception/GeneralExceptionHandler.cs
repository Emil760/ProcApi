using System.Net.Mime;
using Microsoft.Extensions.Localization;
using ProcApi.Domain.Models;
using ProcApi.Infrastructure.Resources;

namespace ProcApi.Presentation.Handlers.Exception;

public class GeneralExceptionHandler : IExceptionHandler
{
    private readonly IStringLocalizer<SharedResource> _localizer;
    private readonly IWebHostEnvironment _hostingEnvironment;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly ILogger<GeneralExceptionHandler> _logger;

    public GeneralExceptionHandler(IStringLocalizer<SharedResource> localizer,
        IWebHostEnvironment hostingEnvironment,
        IHttpContextAccessor httpContextAccessor,
        ILogger<GeneralExceptionHandler> logger)
    {
        _localizer = localizer;
        _hostingEnvironment = hostingEnvironment;
        _httpContextAccessor = httpContextAccessor;
        _logger = logger;
    }

    public ExceptionModel Handle(System.Exception exception)
    {
        if (_hostingEnvironment.IsProduction())
        {
            _logger.LogCritical(exception, "InternalServerError");

            return new ExceptionModel
            {
                ContentType = MediaTypeNames.Text.Plain,
                StatusCode = 500,
                Message = _localizer["InternalServerError"]
            };
        }

        var errorMessage = GetFailedRequestMessage(_httpContextAccessor.HttpContext!, exception);
        _logger.LogCritical(errorMessage);

        return new ExceptionModel
        {
            ContentType = MediaTypeNames.Text.Plain,
            StatusCode = 500,
            Message = exception.Message + "." + exception.InnerException?.Message
        };
    }

    private string GetFailedRequestMessage(HttpContext context, System.Exception exception)
    {
        return "Failed Request\n" +
               $"\tSchema: {context.Request.Scheme}\n" +
               $"\tHost: {context.Request.Host}\n" +
               $"\tMethod: {context.Request.Method}\n" +
               $"\tPath: {context.Request.Path}\n" +
               $"\tQueryString: {context.Request.QueryString}\n" +
               $"\tErrorMessage: {exception.Message}\n" +
               $"\tStacktrace:\n{exception.StackTrace?.Split('\n').Aggregate((a, b) => a + "\n" + b)}";
    }
}