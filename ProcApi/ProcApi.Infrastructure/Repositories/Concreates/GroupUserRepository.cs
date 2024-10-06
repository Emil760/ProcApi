using Microsoft.EntityFrameworkCore;
using ProcApi.Domain.Entities;
using ProcApi.Domain.Enums;
using ProcApi.Infrastructure.Data;
using ProcApi.Infrastructure.Repositories.Abstracts;

namespace ProcApi.Infrastructure.Repositories.Concreates;

public class GroupUserRepository : GenericRepository<GroupUser, int>, IGroupUserRepository
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