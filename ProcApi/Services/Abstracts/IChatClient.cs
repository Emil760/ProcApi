using ProcApi.DTOs.Chat.Signals;

namespace ProcApi.Services.Abstracts;

public interface IChatClient
{
    Task SendUserMessageAsync(SendMessageSignalDto dto);
    Task MarkAsReadAsync(MarkAsReadSignalDto dto);
    Task GroupCreatedAsync(GroupCreatedSignalDto dto);
}