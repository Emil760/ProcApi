﻿using Microsoft.EntityFrameworkCore;
using ProcApi.Data.ProcDatabase;
using ProcApi.Data.ProcDatabase.Models;
using ProcApi.Repositories.Abstracts;

namespace ProcApi.Repositories.Concreates
{
    public class ChatMessageRepository : GenericRepository<ChatMessage>, IChatMessageRepository
    {
        public ChatMessageRepository(ProcDbContext context) : base(context)
        {
        }

        public async Task<ChatMessage?> GetWithChatUsersByIdAsync(int id)
        {
            return await _context.ChatMessages
                .Include(cm => cm.Chat.ChatUsers)
                .SingleOrDefaultAsync(cm => cm.Id == id);
        }
    }
}