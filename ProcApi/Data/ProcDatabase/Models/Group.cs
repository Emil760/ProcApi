using ProcApi.Data.ProcDatabase.Enums;

namespace ProcApi.Data.ProcDatabase.Models;

public class Group
{
    public int Id { get; set; }
    public int ContactTypeId { get; set; }
    public ContactType ContactType { get; set; }
    public string Name { get; set; }
    public ICollection<User> Users { get; set; }
    public ICollection<ChatMessage> ChatMessages { get; set; }
}