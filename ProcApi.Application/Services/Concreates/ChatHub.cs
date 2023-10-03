using Microsoft.AspNetCore.SignalR;
using ProcApi.Application.Services.Abstracts;

namespace ProcApi.Application.Services.Concreates;

public class ChatHub : Hub<IChatClient>
{
    private readonly IConnectedUsersService _connectedUsersService;

    public ChatHub(IConnectedUsersService connectedUsersService)
    {
        _connectedUsersService = connectedUsersService;
    }

    public override async Task OnDisconnectedAsync(Exception? exception)
    {
        await _connectedUsersService.RemoveConnectionIdAsync(Context.ConnectionId);
        await base.OnDisconnectedAsync(exception);
    }
}