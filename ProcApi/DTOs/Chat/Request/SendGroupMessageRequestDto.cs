namespace ProcApi.DTOs.Chat.Request;

public class SendGroupMessageRequestDto
{
    public int ChatId { get; set; }
    public string Message { get; set; }
}