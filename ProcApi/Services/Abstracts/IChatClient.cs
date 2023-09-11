using ProcApi.DTOs.Chat.Signals;

namespace ProcApi.Services.Abstracts;

public interface IChatClient
{
    Task SendUserMessage(SendMessageSignalDto signalDto);
    Task MarkAsRead(MarkAsReadSignalDto dto);
}