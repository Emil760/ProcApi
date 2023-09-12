using ProcApi.Handlers.Exception;

namespace ProcApi.Middleware
{
    public class CustomExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public CustomExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, ExceptionHandlerCoordinator coordinator)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                var resultDto = coordinator.Handle(ex);

                context.Response.ContentType = resultDto.ContentType;
                context.Response.StatusCode = resultDto.StatusCode;

                await context.Response.WriteAsync(resultDto.Message);
            }
        }
    }

    public static class CustomExceptionHandlerMiddlewareExtension
    {
        public static void UseCustomExceptionHandlerMiddleware(this IApplicationBuilder builder)
        {
            builder.UseMiddleware<CustomExceptionHandlerMiddleware>();
        }
    }
}