using ProcApi.Application.DTOs.Chat.Signals;

namespace ProcApi.Application.Services.Abstracts;

public interface IChatClient
{
    Task SendUserMessageAsync(SendMessageSignalDto dto);
    Task MarkAsReadAsync(MarkAsReadSignalDto dto);
    Task GroupCreatedAsync(GroupCreatedSignalDto dto);
    Task UserPromotedRoleAsync(UserPromotedRoleSignalDto dto);
    Task UserLeavedGroupAsync(UserLeavedGroupSignalDto dto);
}