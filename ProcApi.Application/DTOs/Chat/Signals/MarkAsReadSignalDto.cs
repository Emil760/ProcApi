namespace ProcApi.Application.DTOs.Chat.Signals;

public class MarkAsReadSignalDto
{
    public int ReceiverId { get; set; }
    public int ChatId { get; set; }
    public int MessageId { get; set; }
    public DateTime ReadTime { get; set; }
    public bool IsRead { get; set; }
}