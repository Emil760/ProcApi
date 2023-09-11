using ProcApi.Data.ProcDatabase.Models;
using ProcApi.DTOs.Chat.Request;

namespace ProcApi.Services.Abstracts;

public interface IChatGroupService
{
    Task<Group> CreateGroupAsync(int creatorId, CreateGroupRequestDto dto);
}