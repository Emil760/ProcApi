namespace ProcApi.Application.DTOs.Chat.Requests;

public class CreateGroupRequest
{
    public string Name { get; set; }
    public IEnumerable<int> UserIds { get; set; }
}