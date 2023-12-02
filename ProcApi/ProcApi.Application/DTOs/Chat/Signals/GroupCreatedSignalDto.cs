using ProcApi.Application.DTOs.Chat.Base;

namespace ProcApi.Application.DTOs.Chat.Signals;

public class GroupCreatedSignalDto : GroupDto
{
    public IEnumerable<GroupUserSignalDto> Users { get; set; }
}