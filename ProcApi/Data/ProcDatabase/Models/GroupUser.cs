using ProcApi.Data.ProcDatabase.Enums;

namespace ProcApi.Data.ProcDatabase.Models;

public class GroupUser : ChatUser
{
    public int GroupId { get; set; }
    public Group Group { get; set; }
    public ChatRole ChatRole { get; set; }
}