using ProcApi.Data.ProcDatabase.Enums;

namespace ProcApi.DTOs.Chat.Base;

public class GroupUserDto
{
    public int ChatUserId { get; set; }
    public int UserId { get; set; }
    public string FirstName { get; set; }
    public ChatRole ChatRole { get; set; }
}