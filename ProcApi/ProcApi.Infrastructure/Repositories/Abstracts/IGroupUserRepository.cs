using ProcApi.Domain.Entities;
using ProcApi.Domain.Enums;

namespace ProcApi.Infrastructure.Repositories.Abstracts;

public interface IGroupUserRepository : IGenericRepository<GroupUser, int>
{
    Task<IEnumerable<int>> GetAllUserIdsByGroupId(int groupId);
    Task<GroupUser?> FindByGroupIdAndUserId(int groupId, int userId);
    Task<GroupUser?> FindByGroupIdAndUserIdAndRole(int groupId, int userId, ChatRole role);
}