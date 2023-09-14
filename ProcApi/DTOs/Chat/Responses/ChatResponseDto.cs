using ProcApi.Data.ProcDatabase.Enums;

namespace ProcApi.DTOs.Chat.Responses;

public class ChatResponseDto
{
    public int ChatId { get; set; }
    public ChatType ChatType { get; set; }
    public string Name { get; set; }
    public string LastMessage { get; set; }
}