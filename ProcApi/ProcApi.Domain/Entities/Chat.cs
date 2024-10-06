using ProcApi.Domain.Enums;
using ProcApi.Domain.Interfaces;

namespace ProcApi.Domain.Entities;

public class Chat : IEntity<int>
{
    public int Id { get; set; }
    public ChatType ChatTypeId { get; set; }
    public ICollection<ChatMessage> ChatMessages { get; set; }
    public ICollection<ChatUser> ChatUsers { get; set; }
}