using ProcApi.Data.ProcDatabase.Models;

namespace ProcApi.Services.Abstracts;

public interface IChatMessageSignalService
{
    Task SendUserSignalMessageAsync(ChatMessage chatMessage, IEnumerable<int> userIds);
    Task SignalMarkAsReadAsync(ReceivedInfo receivedInfo, ChatMessage chatMessage);
}