namespace ProcApi.Middleware
{
    public class CustomExeptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public CustomExeptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                if(context.Response.StatusCode == 400)
                {
                    var a = context.Response.Body;

                    var error = new ErrorModel()
                    {
                        Code = "",
                        Message = "",
                        Name = "",
                        Type = 1
                    };
                }

                await _next(context);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }

    public static class CustomExeptionHandlerMiddlewareExtension
    {
        public static void UseCustomExeptionHandlerMiddleware(this IApplicationBuilder builder)
        {
            builder.UseMiddleware<CustomExeptionHandlerMiddleware>();
        }
    }

    public class ErrorModel
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string Message { get; set; }
        public int Type { get; set; }
    }
}
