namespace ProcApi.DTOs.Chat.Request;

public class SendChatUserMessageRequestDto
{
    public int ReceiverUserId { get; set; }
    public string Message { get; set; }
}