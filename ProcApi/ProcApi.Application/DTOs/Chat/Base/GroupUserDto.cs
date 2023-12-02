using ProcApi.Domain.Enums;

namespace ProcApi.Application.DTOs.Chat.Base;

public class GroupUserDto
{
    public int ChatUserId { get; set; }
    public int UserId { get; set; }
    public string FirstName { get; set; }
    public ChatRole ChatRole { get; set; }
}