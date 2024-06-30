namespace ProcApi.Domain.Exceptions;

public class ItemsException<T> : Exception
{
    public IEnumerable<T> Items { get; set; }

    public ItemsException()
    {
        
    }
    
    public ItemsException(string message, IEnumerable<T> items) : base(message)
    {
        Items = items;
    }
}