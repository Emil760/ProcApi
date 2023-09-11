using ProcApi.Data.ProcDatabase.Models;
using ProcApi.DTOs.Base;
using ProcApi.DTOs.Chat.Responses;

namespace ProcApi.Services.Abstracts
{
    public interface IChatService
    {
        Task ConnectAsync(int userId, string connectionId);
        Task<Chat> CreateChatBetweenUsersAsync(IEnumerable<int> userIds);
        Task<IEnumerable<ChatUserResponseDto>> GetUsersAsync(PaginationRequestDto dto);
        Task<IEnumerable<ChatResponseDto>> GetChatsAsync(int userId);
    }
}