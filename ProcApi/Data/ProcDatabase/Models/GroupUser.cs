using ProcApi.Data.ProcDatabase.Enums;

namespace ProcApi.Data.ProcDatabase.Models;

public class GroupUser
{
    public int GroupId { get; set; }
    public Group Group { get; set; }
    public int ChatUserId { get; set; }
    public ChatUser ChatUser { get; set; }
    public ChatRole ChatRole { get; set; }
    public bool IsLeaved { get; set; }
}