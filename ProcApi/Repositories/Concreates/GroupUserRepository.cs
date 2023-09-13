using Microsoft.EntityFrameworkCore;
using ProcApi.Data.ProcDatabase;
using ProcApi.Data.ProcDatabase.Enums;
using ProcApi.Data.ProcDatabase.Models;
using ProcApi.Repositories.Abstracts;

namespace ProcApi.Repositories.Concreates;

public class GroupUserRepository : GenericRepository<GroupUser>, IGroupUserRepository
{
    public GroupUserRepository(ProcDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<int>> GetAllUserIdsByGroupId(int groupId)
    {
        return await _context.GroupUsers
            .Where(gu => gu.GroupId == groupId)
            .Select(gu => gu.ChatUser.UserId)
            .ToListAsync();
    }

    public async Task<GroupUser?> FindByGroupIdAndUserId(int groupId, int userId)
    {
        return await _context.GroupUsers
            .SingleOrDefaultAsync(gu => gu.GroupId == groupId
                                        && gu.ChatUser.UserId == userId);
    }

    public async Task<GroupUser?> FindByGroupIdAndUserIdAndRole(int groupId, int userId, ChatRole role)
    {
        return await _context.GroupUsers
            .SingleOrDefaultAsync(gu => gu.GroupId == groupId
                                        && gu.ChatUser.UserId == userId
                                        && gu.ChatRole == ChatRole.Admin);
    }
}