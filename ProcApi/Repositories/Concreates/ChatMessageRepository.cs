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
    }
}
