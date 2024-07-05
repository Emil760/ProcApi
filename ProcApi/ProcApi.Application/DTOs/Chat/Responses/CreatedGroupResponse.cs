using ProcApi.Application.DTOs.Chat.Base;

namespace ProcApi.Application.DTOs.Chat.Responses;

public class CreatedGroupResponse : GroupDto
{
    public IEnumerable<GroupUserResponse> Users { get; set; }
}