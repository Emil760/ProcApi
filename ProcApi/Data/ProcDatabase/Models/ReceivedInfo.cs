namespace ProcApi.Data.ProcDatabase.Models;

public class ReceivedInfo
{
    public int ReceiverId { get; set; }
    public bool IsRead { get; set; }
    public DateTime? ReadTime { get; set; }
}