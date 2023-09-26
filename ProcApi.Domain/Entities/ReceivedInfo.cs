namespace ProcApi.Domain.Entities;

public class ReceivedInfo
{
    public int ReceiverId { get; set; }
    public bool IsRead { get; set; }
    public DateTime? ReadTime { get; set; }
}