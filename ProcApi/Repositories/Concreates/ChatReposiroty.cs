using Microsoft.EntityFrameworkCore;
using ProcApi.Data.ProcDatabase;
using ProcApi.Data.ProcDatabase.Models;
using ProcApi.Repositories.Abstracts;

namespace ProcApi.Repositories.Concreates;

public class ChatRepository : GenericRepository<Chat>, IChatRepository
{
    public ChatRepository(ProcDbContext context) : base(context)
    {
    }

    public async Task<Chat?> FindWithChatUsersByAllUserIdsAsync(IEnumerable<int> userIds)
    {
        return await _context.Chats
            .Include(c => c.ChatUsers)
            .Where(c => c.ChatUsers.All(cu => userIds.Contains(cu.UserId)))
            .SingleOrDefaultAsync();
    }

    public async Task<IEnumerable<Chat>> GetChatsByUserIdAsync(int userId)
    {
        // return await _context.Chats
        //     .Include(c => c.Group)
        //     .Include(c => c.ChatUsers.Where(cu => cu.UserId == userId))
        //     .ThenInclude(cu => cu.User)
        //     .Where(c => c.Group.GroupUsers.Any(cu => cu.UserId == userId)
        //                 && c.ChatUsers.Any(cu => cu.UserId != userId))
        //     .ToListAsync();
        
        //TODO
        return null;
    }
}