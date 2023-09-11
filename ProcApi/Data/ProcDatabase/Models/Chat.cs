using ProcApi.Data.ProcDatabase.Enums;

namespace ProcApi.Data.ProcDatabase.Models;

public class Chat
{
    public int Id { get; set; }
    public ChatType ChatType { get; set; }
    public ICollection<ChatMessage> ChatMessages { get; set; }
    public ICollection<ChatUser> ChatUsers { get; set; }
}