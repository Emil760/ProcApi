using AutoMapper;
using Microsoft.AspNetCore.SignalR;
using ProcApi.Application.DTOs.Chat.Signals;
using ProcApi.Application.Services.Abstracts;
using ProcApi.Domain.Entities;

namespace ProcApi.Application.Services.Concreates;

public class ChatMessageSignalService : IChatMessageSignalService
{
    private readonly IHubContext<ChatHub, IChatClient> _chatHub;
    private readonly IConnectedUsersService _connectedUsersService;
    private readonly IMapper _mapper;
    
    public ChatMessageSignalService(IHubContext<ChatHub, IChatClient> chatHub,
        IConnectedUsersService connectedUsersService,
        IMapper mapper)
    {
        _chatHub = chatHub;
        _connectedUsersService = connectedUsersService;
        _mapper = mapper;
    }
    
    public async Task SendUserSignalMessageAsync(ChatMessage chatMessage, IEnumerable<int> userIds)
    {
        var connectionIds = await _connectedUsersService.GetConnectionsAsync(userIds);

        var sendMessage = _mapper.Map<SendMessageSignalDto>(chatMessage);

        foreach (var connectionId in connectionIds)
        {
            await _chatHub.Clients.Client(connectionId)
                .SendUserMessageAsync(sendMessage);
        }
    }
    
    public async Task SignalMarkAsReadAsync(ReceivedInfo receivedInfo, ChatMessage chatMessage)
    {
        var userIds = chatMessage.Chat.ChatUsers
            .Where(cu => cu.UserId != receivedInfo.ReceiverId)
            .Select(cu => cu.UserId);

        var connectionIds = await _connectedUsersService.GetConnectionsAsync(userIds);

        var markAsReadSignalDto = _mapper.Map<MarkAsReadSignalDto>((receivedInfo, chatMessage));

        foreach (var connectionId in connectionIds)
        {
            _chatHub.Clients.Client(connectionId)
                .MarkAsReadAsync(markAsReadSignalDto);
        }
    }
}