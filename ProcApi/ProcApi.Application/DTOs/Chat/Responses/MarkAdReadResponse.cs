namespace ProcApi.Application.DTOs.Chat.Responses;

public class MarkAdReadResponse
{
    public int MessageId { get; set; }
    public int ReceiverId { get; set; }
    public DateTime ReadTime { get; set; }
    public bool IsRead { get; set; }
}