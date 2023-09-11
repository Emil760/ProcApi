using ProcApi.Data.ProcDatabase.Enums;
using ProcApi.Data.ProcDatabase.Models;
using ProcApi.DTOs.Chat.Request;
using ProcApi.Repositories.Abstracts;
using ProcApi.Repositories.UnitOfWork;
using ProcApi.Services.Abstracts;

namespace ProcApi.Services.Concreates;

public class ChatGroupService : IChatGroupService
{
    private readonly IGroupRepository _groupRepository;
    private readonly IUnitOfWork _unitOfWork;

    public ChatGroupService(IGroupRepository groupRepository,
        IUnitOfWork unitOfWork)
    {
        _groupRepository = groupRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Group> CreateGroupAsync(int creatorId, CreateGroupRequestDto dto)
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
            UserId = creatorId,
            ChatRole = ChatRole.Admin
        };

        group.GroupUsers = new List<GroupUser>();
        group.GroupUsers.Add(creatorUser);

        foreach (var userId in dto.UserIds)
        {
            group.GroupUsers.Add(new GroupUser()
            {
                ChatRole = ChatRole.User,
                UserId = userId
            });
        }

        _groupRepository.Insert(group);

        await _unitOfWork.SaveChangesAsync();

        return group;
    }
}