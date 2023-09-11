namespace ProcApi.Data.ProcDatabase.Models;

public class ReceivedInfo
{
    public int ReceiverId { get; set; }
    public User Receiver { get; set; }
    public bool IsRead { get; set; }
    public DateTime? ReadTime { get; set; }
}