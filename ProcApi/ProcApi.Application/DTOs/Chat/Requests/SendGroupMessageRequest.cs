namespace ProcApi.Application.DTOs.Chat.Requests;

public class SendGroupMessageRequest
{
    public int ChatId { get; set; }
    public string Message { get; set; }
}