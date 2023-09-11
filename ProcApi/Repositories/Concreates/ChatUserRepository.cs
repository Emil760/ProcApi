using Microsoft.EntityFrameworkCore;
using ProcApi.Data.ProcDatabase;
using ProcApi.Data.ProcDatabase.Models;
using ProcApi.Repositories.Abstracts;

namespace ProcApi.Repositories.Concreates;

public class ChatUserRepository : GenericRepository<ChatUser>, IChatUserRepository
{
    public ChatUserRepository(ProcDbContext context) : base(context)
    {
    }

    public async Task<bool> AllExistsByUserIds(IEnumerable<int> userIds)
    {
        return await _context.ChatUsers.AllAsync(cu => userIds.Contains(cu.UserId));
    }
}