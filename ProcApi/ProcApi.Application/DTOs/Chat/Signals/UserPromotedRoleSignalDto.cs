using ProcApi.Domain.Enums;

namespace ProcApi.Application.DTOs.Chat.Signals;

public class UserPromotedRoleSignalDto
{
    public int GroupId { get; set; }
    public int FromUserId { get; set; }
    public int ToUserId { get; set; }
    public ChatRole ChatRole { get; set; }
}