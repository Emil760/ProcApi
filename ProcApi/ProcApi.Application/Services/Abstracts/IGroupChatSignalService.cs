using ProcApi.Domain.Entities;
using ProcApi.Domain.Enums;

namespace ProcApi.Application.Services.Abstracts;

public interface IGroupChatSignalService
{
    Task SignalGroupCreatedAsync(int creatorUserId, Group group);
    Task SignalUserPromotedRoleAsync(int currentUserId, int userId, int groupId, ChatRole role);
    Task SignalUserLeavedGroup(int groupId, int userId);
}