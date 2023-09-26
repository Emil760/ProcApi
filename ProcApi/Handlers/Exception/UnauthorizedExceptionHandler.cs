﻿using System.Net.Mime;
using ProcApi.DTOs.Exception;

namespace ProcApi.Handlers.Exception;

public class UnauthorizedExceptionHandler : IExceptionHandler
{
    public ExceptionResultDto Handle(System.Exception exception)
    {
        return new ExceptionResultDto()
        {
            ContentType = MediaTypeNames.Text.Plain,
            StatusCode = 401,
            Message = exception.Message
        };
    }
}