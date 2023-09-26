namespace ProcApi.Domain.Models;

public class ExceptionModel
{
    public int StatusCode { get; set; }
    public string ContentType { get; set; }
    public string Message { get; set; }
}