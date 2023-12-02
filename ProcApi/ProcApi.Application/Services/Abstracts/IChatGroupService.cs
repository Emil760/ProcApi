using ProcApi.Application.DTOs.Chat.Request;
using ProcApi.Application.DTOs.Chat.Responses;

namespace ProcApi.Application.Services.Abstracts;

public interface IChatGroupService
{
    Task<CreatedGroupResponseDto> CreateGroupAsync(int creatorUserId, CreateGroupRequestDto dto);
    Task GiveAdminAsync(int currentUserId, int groupId, int userId);
    Task RemoveAdminAsync(int currentUserId, int groupId, int userId);
    Task LeaveGroup(int groupId, int userId);
}