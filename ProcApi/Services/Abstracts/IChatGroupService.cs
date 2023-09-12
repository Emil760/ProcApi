using ProcApi.DTOs.Chat.Request;
using ProcApi.DTOs.Chat.Responses;

namespace ProcApi.Services.Abstracts;

public interface IChatGroupService
{
    Task<CreatedGroupResponseDto> CreateGroupAsync(int creatorUserId, CreateGroupRequestDto dto);
}