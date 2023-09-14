using Microsoft.EntityFrameworkCore;
using ProcApi.Data.ProcDatabase;
using ProcApi.Data.ProcDatabase.Models;
using ProcApi.Repositories.Abstracts;

namespace ProcApi.Repositories.Concreates;

public class GroupRepository : GenericRepository<Group>, IGroupRepository
{
    public GroupRepository(ProcDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Group>> GetAllWithLastMessageByUserId(int userId)
    {
        return await _context.Groups
            .Include(g => g.Chat.ChatMessages.OrderByDescending(cm => cm.SendTime).Take(1))
            .Include(cu => cu.Chat)
            .Where(g => g.GroupUsers.Any(gu => gu.ChatUser.UserId == userId))
            .ToListAsync();
    }
}