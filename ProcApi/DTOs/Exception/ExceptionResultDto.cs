
namespace ProcApi.DTOs.Exception;

public class ExceptionResultDto
{
    public int StatusCode { get; set; }
    public string ContentType { get; set; }
    public string Message { get; set; }
}