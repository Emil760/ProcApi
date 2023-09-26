﻿using Microsoft.EntityFrameworkCore;
using ProcApi.Domain.Entities;
using ProcApi.Infrastructure.Data;
using ProcApi.Infrastructure.Repositories.Abstracts;

namespace ProcApi.Infrastructure.Repositories.Concreates
{
    public class ChatMessageRepository : GenericRepository<ChatMessage>, IChatMessageRepository
    {
        public ChatMessageRepository(ProcDbContext context) : base(context)
        {
        }

        public async Task<ChatMessage?> GetWithChatUsersExceptCurrentUserByIdAsync(int id, int userId)
        {
            return await _context.ChatMessages
                .Include(cm => cm.Chat.ChatUsers.Where(cu => cu.UserId != userId))
                .SingleOrDefaultAsync(cm => cm.Id == id);
        }
    }
}