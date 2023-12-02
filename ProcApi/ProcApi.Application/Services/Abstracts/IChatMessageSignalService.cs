using ProcApi.Domain.Entities;

namespace ProcApi.Application.Services.Abstracts;

public interface IChatMessageSignalService
{
    Task SendUserSignalMessageAsync(ChatMessage chatMessage, IEnumerable<int> userIds);
    Task SignalMarkAsReadAsync(ReceivedInfo receivedInfo, ChatMessage chatMessage);
}