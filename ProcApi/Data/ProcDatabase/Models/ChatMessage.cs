namespace ProcApi.Data.ProcDatabase.Models;

public class ChatMessage
{
    public int Id { get; set; }
    public int FromId { get; set; }
    public required User From { get; set; }
    public int ToId { get; set; }
    public required User To { get; set; }
    public string Message { get; set; }
}