using ProcApi.DTOs.Chat.Base;

namespace ProcApi.DTOs.Chat.Signals;

public class GroupCreatedSignalDto : GroupDto
{
    public IEnumerable<GroupUserSignalDto> Users { get; set; }
}