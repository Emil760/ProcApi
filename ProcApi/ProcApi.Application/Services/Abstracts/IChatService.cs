using ProcApi.Application.DTOs.Chat.Responses;
using ProcApi.Domain.Entities;
using ProcApi.Domain.Models;

namespace ProcApi.Application.Services.Abstracts;

public interface IChatService
{
    Task ConnectAsync(int userId, string connectionId);
    Task<Chat> CreateChatBetweenUsersAsync(IEnumerable<int> userIds);
    Task<IEnumerable<ChatUserResponse>> GetUsersAsync(PaginationModel pagination);
    Task<IEnumerable<ChatResponse>> GetChatsAsync(int userId);
}