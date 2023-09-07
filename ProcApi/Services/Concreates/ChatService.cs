using ProcApi.Data.ProcDatabase.Models;
using ProcApi.Repositories.Abstracts;
using ProcApi.Services.Abstracts;

namespace ProcApi.Services.Concreates
{
    public class ChatService : IChatService
    {
        private readonly IUserRepository _userRepository;
        private readonly IChatMessageRepository _chatMessageRepository;
        private readonly SemaphoreSlim _semaphore = new SemaphoreSlim(1);

        public ChatService(IUserRepository userRepository,
            IChatMessageRepository chatMessageRepository)
        {
            _userRepository = userRepository;
            _chatMessageRepository = chatMessageRepository;
        }

        public async Task SendBulk(int userId, string message)
        {
            var from = await _userRepository.GetByIdAsync(userId);

            var sendTasks = new List<Task>();

            var users = await _userRepository.GetAllByConditionAsync(u => u.Id != userId);

            foreach (var user in users)
                sendTasks.Add(SendMessage(from, user, message));
            
            await Task.WhenAll(sendTasks);
        }

        private async Task SendMessage(User from, User to, string message)
        {
            var chatMessage = new ChatMessage
            {
                // From = from,
                // To = to,
                // Message = message
            };

            await _semaphore.WaitAsync();

            try
            {
                await _chatMessageRepository.InsertAsync(chatMessage);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                _semaphore.Release();
            }
        }

    }
}
