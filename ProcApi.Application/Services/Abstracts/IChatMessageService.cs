using ProcApi.Application.DTOs.Chat.Request;
using ProcApi.Application.DTOs.Chat.Responses;

namespace ProcApi.Application.Services.Abstracts;

public interface IChatMessageService
{
    Task SendMessageToUserAsync(int senderUserId, SendChatUserMessageRequestDto dto);
    Task SendMessageToGroupAsync(int senderUserId, SendGroupMessageRequestDto dto);
    Task<MarkAdReadResponseDto?> MarkAsReadAsync(int messageId, int receiverId);
}