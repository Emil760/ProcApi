using ProcApi.Application.DTOs.Chat.Requests;
using ProcApi.Application.DTOs.Chat.Responses;

namespace ProcApi.Application.Services.Abstracts;

public interface IChatMessageService
{
    Task SendMessageToUserAsync(int senderUserId, SendChatUserMessageRequest dto);
    Task SendMessageToGroupAsync(int senderUserId, SendGroupMessageRequest dto);
    Task<MarkAdReadResponse?> MarkAsReadAsync(int messageId, int receiverId);
}