using ProcApi.Data.ProcDatabase.Enums;

namespace ProcApi.Data.ProcDatabase.Models;

public class User
{
    public int Id { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public int Age { get; set; }
    public Gender Gender { get; set; }

    //public ICollection<ApprovalFlowTemplate> ApprovalFlowTemplates { get; set; }

    public ICollection<ChatMessage> FromChatMessages { get; set; }
    public ICollection<ChatMessage> ToChatMessages { get; set; }

    public ICollection<Delegation> FromDelegations { get; set; }
    public ICollection<Delegation> ToDelegations { get; set; }
}