namespace ProcApi.Application.DTOs.Chat.Requests;

public class SendChatUserMessageRequest
{
    public int ReceiverUserId { get; set; }
    public string Message { get; set; }
}