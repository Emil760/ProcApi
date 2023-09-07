﻿using ProcApi.Exceptions;
using ProcApi.Handlers.Exception;
using ProcApi.Handlers.Exceptions;

namespace ProcApi.Middleware
{
    public class CustomExceptionHandlerMiddleware
    {
        private static readonly Dictionary<Type, IExceptionHandler> _handlers = new Dictionary<Type, IExceptionHandler>()
        {
            { typeof(Exception), new GeneralExceptionHandler() },
            { typeof(NotFoundException), new NotFoundExceptionHandler() },
            { typeof(ValidationExceptipn), new ValidationExceptionHandler() }
        };

        private readonly RequestDelegate _next;

        private int a;

        public CustomExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                if (context.Response.StatusCode == 400)
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
                _handlers[ex.GetType()].Handle();
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

    public class ErrorModel
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string Message { get; set; }
        public int Type { get; set; }
    }
}
