using ProcApi.Domain.Enums;

namespace ProcApi.Application.DTOs.Chat.Responses;

public class ChatResponse
{
    public int ChatId { get; set; }
    public ChatType ChatType { get; set; }
    public string Name { get; set; }
    public string LastMessage { get; set; }
}