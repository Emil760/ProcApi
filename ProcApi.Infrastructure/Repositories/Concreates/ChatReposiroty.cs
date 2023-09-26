using Microsoft.EntityFrameworkCore;
using ProcApi.Domain.Entities;
using ProcApi.Infrastructure.Data;
using ProcApi.Infrastructure.Repositories.Abstracts;

namespace ProcApi.Infrastructure.Repositories.Concreates
{
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

        public async Task<Chat?> FindWithChatUsersExceptCurrUserByChatIdAsync(int chatId, int userId)
        {
            return await _context.Chats
                .Include(c => c.ChatUsers.Where(cu => cu.UserId != userId))
                .Where(c => c.Id == chatId)
                .SingleOrDefaultAsync();
        }
    }
}