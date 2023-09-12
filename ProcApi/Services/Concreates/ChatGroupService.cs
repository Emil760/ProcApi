using AutoMapper;
using Microsoft.AspNetCore.SignalR;
using ProcApi.Data.ProcDatabase;
using ProcApi.Data.ProcDatabase.Enums;
using ProcApi.Data.ProcDatabase.Models;
using ProcApi.DTOs.Chat.Request;
using ProcApi.DTOs.Chat.Responses;
using ProcApi.DTOs.Chat.Signals;
using ProcApi.Repositories.Abstracts;
using ProcApi.Repositories.UnitOfWork;
using ProcApi.Services.Abstracts;

namespace ProcApi.Services.Concreates;

public class ChatGroupService : IChatGroupService
{
    private readonly IHubContext<ChatHub, IChatClient> _hubContext;
    private readonly IConnectedUsersService _connectedUsersService;
    private readonly IGroupRepository _groupRepository;
    private readonly IUserRepository _userRepository;
    private readonly IChatRepository _chatRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly ProcDbContext _context;

    public ChatGroupService(IHubContext<ChatHub, IChatClient> hubContext,
        IConnectedUsersService connectedUsersService,
        IGroupRepository groupRepository,
        IUserRepository userRepository,
        IChatRepository chatRepository,
        IUnitOfWork unitOfWork,
        IMapper mapper,
        ProcDbContext context)
    {
        _hubContext = hubContext;
        _connectedUsersService = connectedUsersService;
        _userRepository = userRepository;
        _groupRepository = groupRepository;
        _chatRepository = chatRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _context = context;
    }

    public async Task<CreatedGroupResponseDto> CreateGroupAsync(int creatorUserId, CreateGroupRequestDto dto)
    {
        var chat = new Chat()
        {
            ChatType = ChatType.Group
        };

        await _chatRepository.InsertAsync(chat);

        var group = new Group()
        {
            Name = dto.Name,
            Chat = chat,
        };

        var creatorUser = new GroupUser()
        {
            ChatUser = new ChatUser()
            {
                Chat = chat,
                UserId = creatorUserId
            },
            ChatRole = ChatRole.Admin
        };

        var groupUsers = new List<GroupUser> { creatorUser };
        groupUsers.AddRange(await AddGroupUsersAsync(chat.Id, dto.UserIds));
        group.GroupUsers = groupUsers;

        _groupRepository.Insert(group);

        await _unitOfWork.SaveChangesAsync();

        //SignalGroupCreatedAsync(creatorUserId, group);

        return _mapper.Map<CreatedGroupResponseDto>(group);
    }

    private async Task<List<GroupUser>> AddGroupUsersAsync(int chatId, IEnumerable<int> userIds)
    {
        var groupUsers = new List<GroupUser>();

        var users = await _userRepository.GetAllAsync(userIds);

        foreach (var user in users)
        {
            groupUsers.Add(new GroupUser()
            {
                ChatUser = new ChatUser()
                {
                    ChatId = chatId,
                    User = user
                },
                ChatRole = ChatRole.User,
            });
        }

        return groupUsers;
    }

    private async Task SignalGroupCreatedAsync(int creatorUserId, Group group)
    {
        var userIds = group.GroupUsers
            .Where(gu => gu.ChatUserId != creatorUserId)
            .Select(gu => gu.ChatUserId);

        var a = _mapper.Map<GroupCreatedSignalDto>(group);

        var connectionIds = await _connectedUsersService.GetConnectionsAsync(userIds);

        foreach (var connectionId in connectionIds)
        {
            _hubContext.Clients.Client(connectionId)
                .GroupCreatedAsync(_mapper.Map<GroupCreatedSignalDto>(group));
        }
    }
}