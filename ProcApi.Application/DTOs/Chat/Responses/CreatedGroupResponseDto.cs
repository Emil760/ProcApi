using ProcApi.Application.DTOs.Chat.Base;

namespace ProcApi.Application.DTOs.Chat.Responses;

public class CreatedGroupResponseDto : GroupDto
{
    public IEnumerable<GroupUserResponseDto> Users { get; set; }
}