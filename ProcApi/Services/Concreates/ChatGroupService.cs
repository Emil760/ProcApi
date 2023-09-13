using AutoMapper;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Localization;
using ProcApi.Data.ProcDatabase;
using ProcApi.Data.ProcDatabase.Enums;
using ProcApi.Data.ProcDatabase.Models;
using ProcApi.DTOs.Chat.Request;
using ProcApi.DTOs.Chat.Responses;
using ProcApi.Exceptions;
using ProcApi.Repositories.Abstracts;
using ProcApi.Repositories.UnitOfWork;
using ProcApi.Resources;
using ProcApi.Services.Abstracts;

namespace ProcApi.Services.Concreates;

public class ChatGroupService : IChatGroupService
{
    private readonly IHubContext<ChatHub, IChatClient> _hubContext;
    private readonly IGroupChatSignalService _groupChatSignalService;
    private readonly IConnectedUsersService _connectedUsersService;
    private readonly IGroupRepository _groupRepository;
    private readonly IUserRepository _userRepository;
    private readonly IChatRepository _chatRepository;
    private readonly IGroupUserRepository _groupUserRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IStringLocalizer<SharedResource> _localizer;
    private readonly ProcDbContext _context;

    public ChatGroupService(IHubContext<ChatHub, IChatClient> hubContext,
        IGroupChatSignalService groupChatSignalService,
        IConnectedUsersService connectedUsersService,
        IGroupRepository groupRepository,
        IUserRepository userRepository,
        IChatRepository chatRepository,
        IGroupUserRepository groupUserRepository,
        IUnitOfWork unitOfWork,
        IMapper mapper,
        IStringLocalizer<SharedResource> localizer,
        ProcDbContext context)
    {
        _hubContext = hubContext;
        _groupChatSignalService = groupChatSignalService;
        _connectedUsersService = connectedUsersService;
        _userRepository = userRepository;
        _groupRepository = groupRepository;
        _chatRepository = chatRepository;
        _groupUserRepository = groupUserRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _localizer = localizer;
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

        //_groupChatSignalService.SignalGroupCreatedAsync(creatorUserId, group);

        return _mapper.Map<CreatedGroupResponseDto>(group);
    }

    public async Task GiveAdminAsync(int currentUserId, int groupId, int userId)
    {
        var currUser = await _groupUserRepository.FindByGroupIdAndUserIdAndRole(groupId, currentUserId, ChatRole.Admin);

        if (currUser is null)
            throw new ValidationException(_localizer["UserIsNotAdmin"]);

        var user = await _groupUserRepository.FindByGroupIdAndUserId(groupId, userId);

        if (user is null)
            throw new FluentValidation.ValidationException(_localizer["UserNotFoundInGroup"]);

        user.ChatRole = ChatRole.Admin;

        await _groupUserRepository.InsertAsync(user);

        //_groupChatSignalService.SignalUserPromotedRoleAsync(currentUserId, userId, groupId, ChatRole.Admin);
    }

    public async Task RemoveAdminAsync(int currentUserId, int groupId, int userId)
    {
        var currUser = await _groupUserRepository.FindByGroupIdAndUserIdAndRole(groupId, currentUserId, ChatRole.Admin);

        if (currUser is null)
            throw new ValidationException(_localizer["UserIsNotAdmin"]);

        var user = await _groupUserRepository.FindByGroupIdAndUserId(groupId, userId);

        if (user is null)
            throw new FluentValidation.ValidationException(_localizer["UserNotFoundInGroup"]);

        user.ChatRole = ChatRole.User;

        await _groupUserRepository.InsertAsync(user);

        //_groupChatSignalService.SignalUserPromotedRoleAsync(currentUserId, userId, groupId, ChatRole.User);
    }

    public async Task LeaveGroup(int groupId, int userId)
    {
        var user = await _groupUserRepository.FindByGroupIdAndUserId(groupId, userId);

        if (user is null)
            throw new FluentValidation.ValidationException(_localizer["UserNotFoundInGroup"]);

        user.IsLeaved = true;

        await _groupUserRepository.InsertAsync(user);

        //_groupChatSignalService.SignalUserLeavedGroup(groupId, userId);
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
}