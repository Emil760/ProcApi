using ProcApi.DTOs.Chat.Base;

namespace ProcApi.DTOs.Chat.Responses;

public class CreatedGroupResponseDto : GroupDto
{
    public IEnumerable<GroupUserResponseDto> Users { get; set; }
}