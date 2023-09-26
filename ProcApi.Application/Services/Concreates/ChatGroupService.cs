using AutoMapper;
using Microsoft.Extensions.Localization;
using ProcApi.Application.DTOs.Chat.Request;
using ProcApi.Application.DTOs.Chat.Responses;
using ProcApi.Application.Services.Abstracts;
using ProcApi.Domain.Entities;
using ProcApi.Domain.Enums;
using ProcApi.Domain.Exceptions;
using ProcApi.Infrastructure.Repositories.Abstracts;
using ProcApi.Infrastructure.Repositories.UnitOfWork;
using ProcApi.Resources;

namespace ProcApi.Application.Services.Concreates;

public class ChatGroupService : IChatGroupService
{
    //TODO remove comments
    private readonly IGroupChatSignalService _groupChatSignalService;
    private readonly IGroupRepository _groupRepository;
    private readonly IUserRepository _userRepository;
    private readonly IGroupUserRepository _groupUserRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IStringLocalizer<SharedResource> _localizer;

    public ChatGroupService(IGroupChatSignalService groupChatSignalService,
        IGroupRepository groupRepository,
        IUserRepository userRepository,
        IGroupUserRepository groupUserRepository,
        IUnitOfWork unitOfWork,
        IMapper mapper,
        IStringLocalizer<SharedResource> localizer)
    {
        _groupChatSignalService = groupChatSignalService;
        _userRepository = userRepository;
        _groupRepository = groupRepository;
        _groupUserRepository = groupUserRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _localizer = localizer;
    }

    public async Task<CreatedGroupResponseDto> CreateGroupAsync(int creatorUserId, CreateGroupRequestDto dto)
    {
        var chat = new Chat()
        {
            ChatType = ChatType.Group
        };

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