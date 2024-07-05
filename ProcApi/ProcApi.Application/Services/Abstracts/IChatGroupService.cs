using ProcApi.Application.DTOs.Chat.Requests;
using ProcApi.Application.DTOs.Chat.Responses;

namespace ProcApi.Application.Services.Abstracts;

public interface IChatGroupService
{
    Task<CreatedGroupResponse> CreateGroupAsync(int creatorUserId, CreateGroupRequest dto);
    Task GiveAdminAsync(int currentUserId, int groupId, int userId);
    Task RemoveAdminAsync(int currentUserId, int groupId, int userId);
    Task LeaveGroup(int groupId, int userId);
}