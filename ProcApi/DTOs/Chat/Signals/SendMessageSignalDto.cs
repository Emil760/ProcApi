namespace ProcApi.DTOs.Chat.Signals;

public class SendMessageSignalDto
{
    public int ChatId { get; set; }
    public int SenderId { get; set; }
    public string Message { get; set; }
    public DateTime SendTime { get; set; }
}