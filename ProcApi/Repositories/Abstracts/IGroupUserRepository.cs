using ProcApi.Data.ProcDatabase.Enums;
using ProcApi.Data.ProcDatabase.Models;

namespace ProcApi.Repositories.Abstracts;

public interface IGroupUserRepository : IGenericRepository<GroupUser>
{
    Task<IEnumerable<int>> GetAllUserIdsByGroupId(int groupId);
    Task<GroupUser?> FindByGroupIdAndUserId(int groupId, int userId);
    Task<GroupUser?> FindByGroupIdAndUserIdAndRole(int groupId, int userId, ChatRole role);
}