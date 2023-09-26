using Microsoft.EntityFrameworkCore;
using ProcApi.Domain.Entities;
using ProcApi.Infrastructure.Data;
using ProcApi.Infrastructure.Repositories.Abstracts;

namespace ProcApi.Infrastructure.Repositories.Concreates
{
    public class ChatUserRepository : GenericRepository<ChatUser>, IChatUserRepository
    {
        public ChatUserRepository(ProcDbContext context) : base(context)
        {
        }

        public async Task<bool> AllExistsByUserIdsAsync(IEnumerable<int> userIds)
        {
            return await _context.ChatUsers.AllAsync(cu => userIds.Contains(cu.UserId));
        }

        public async Task<IEnumerable<ChatUser>> GetAllWithLastMessageByUserIdAsync(int userId)
        {
            var query = _context.ChatUsers
                .Where(cu => cu.UserId == userId)
                .Select(cu => cu.ChatId);

            return await _context.ChatUsers
                .Include(cu => cu.Chat.ChatMessages.OrderByDescending(cm => cm.SendTime).Take(1))
                .Include(cu => cu.Chat)
                .Where(cu => cu.UserId != userId && query.Contains(cu.ChatId))
                .ToListAsync();
        }
    }
}