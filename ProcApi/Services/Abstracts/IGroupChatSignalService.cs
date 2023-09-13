using ProcApi.Data.ProcDatabase.Enums;
using ProcApi.Data.ProcDatabase.Models;

namespace ProcApi.Services.Abstracts;

public interface IGroupChatSignalService
{
    Task SignalGroupCreatedAsync(int creatorUserId, Group group);
    Task SignalUserPromotedRoleAsync(int currentUserId, int userId, int groupId, ChatRole role);
    Task SignalUserLeavedGroup(int groupId, int userId);
}