using ProcApi.Domain.Enums;

namespace ProcApi.Domain.Entities;

public class Chat
{
    public int Id { get; set; }
    public ChatType ChatType { get; set; }
    public ICollection<ChatMessage> ChatMessages { get; set; }
    public ICollection<ChatUser> ChatUsers { get; set; }
}