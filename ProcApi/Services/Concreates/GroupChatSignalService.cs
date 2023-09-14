using AutoMapper;
using Microsoft.AspNetCore.SignalR;
using ProcApi.Data.ProcDatabase.Enums;
using ProcApi.Data.ProcDatabase.Models;
using ProcApi.DTOs.Chat.Signals;
using ProcApi.Repositories.Abstracts;
using ProcApi.Services.Abstracts;

namespace ProcApi.Services.Concreates;

public class GroupChatSignalService : IGroupChatSignalService
{
    private readonly IHubContext<ChatHub, IChatClient> _hubContext;
    private readonly IConnectedUsersService _connectedUsersService;
    private readonly IGroupUserRepository _groupUserRepository;
    private readonly IMapper _mapper;

    public GroupChatSignalService(IHubContext<ChatHub, IChatClient> hubContext,
        IConnectedUsersService connectedUsersService,
        IGroupUserRepository groupUserRepository,
        IMapper mapper)
    {
        _hubContext = hubContext;
        _connectedUsersService = connectedUsersService;
        _groupUserRepository = groupUserRepository;
        _mapper = mapper;
    }

    public async Task SignalGroupCreatedAsync(int creatorUserId, Group group)
    {
        var userIds = group.GroupUsers
            .Where(gu => gu.ChatUserId != creatorUserId)
            .Select(gu => gu.ChatUserId);
        
        var connectionIds = await _connectedUsersService.GetConnectionsAsync(userIds);

        foreach (var connectionId in connectionIds)
        {
            _hubContext.Clients.Client(connectionId)
                .GroupCreatedAsync(_mapper.Map<GroupCreatedSignalDto>(group));
        }
    }

    public async Task SignalUserPromotedRoleAsync(int currentUserId, int userId, int groupId, ChatRole role)
    {
        var userIds = await _groupUserRepository.GetAllUserIdsByGroupId(groupId);

        var connectionIds = await _connectedUsersService.GetConnectionsAsync(userIds);

        var dto = new UserPromotedRoleSignalDto()
        {
            GroupId = groupId,
            FromUserId = currentUserId,
            ToUserId = userId,
            ChatRole = role
        };

        foreach (var connectionId in connectionIds)
        {
            _hubContext.Clients.Client(connectionId)
                .UserPromotedRoleAsync(dto);
        }
    }

    public async Task SignalUserLeavedGroup(int groupId, int userId)
    {
        var userIds = await _groupUserRepository.GetAllUserIdsByGroupId(groupId);

        var connectionIds = await _connectedUsersService.GetConnectionsAsync(userIds);

        var dto = new UserLeavedGroupSignalDto()
        {
            GroupId = groupId,
            UserId = userId
        };

        foreach (var connectionId in connectionIds)
        {
            _hubContext.Clients.Client(connectionId)
                .UserLeavedGroupAsync(dto);
        }
    }
}