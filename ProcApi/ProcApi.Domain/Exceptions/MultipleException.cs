namespace ProcApi.Domain.Exceptions;

public class MultipleException : Exception
{
    public MultipleException(List<string> errors)
    {
        Errors = errors;
    }
    
    public List<string> Errors { get; set; }
}