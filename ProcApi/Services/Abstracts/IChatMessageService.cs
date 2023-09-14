using ProcApi.DTOs.Chat.Request;
using ProcApi.DTOs.Chat.Responses;

namespace ProcApi.Services.Abstracts;

public interface IChatMessageService
{
    Task SendMessageToUserAsync(int senderUserId, SendChatUserMessageRequestDto dto);
    Task SendMessageToGroupAsync(int senderUserId, SendGroupMessageRequestDto dto);
    Task<MarkAdReadResponseDto?> MarkAsReadAsync(int messageId, int receiverId);
}