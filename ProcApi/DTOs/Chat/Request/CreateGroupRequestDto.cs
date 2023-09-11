namespace ProcApi.DTOs.Chat.Request;

public class CreateGroupRequestDto
{
    public string Name { get; set; }
    public IEnumerable<int> UserIds { get; set; }
}