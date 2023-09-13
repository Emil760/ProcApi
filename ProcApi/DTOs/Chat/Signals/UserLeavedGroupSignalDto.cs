namespace ProcApi.DTOs.Chat.Signals;

public class UserLeavedGroupSignalDto
{
    public int GroupId { get; set; }
    public int UserId { get; set; }
}