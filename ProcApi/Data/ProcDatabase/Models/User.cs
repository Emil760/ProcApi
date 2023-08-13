using ProcApi.Data.ProcDatabase.Enums;

namespace ProcApi.Data.ProcDatabase.Models;

public class User
{
    public int Id { get; set; }
    public string Login { get; set; }
    public string FirstName { get; set; }
    public Gender Gender { get; set; }
    
    public UserPassword UserPassword { get; set; }
    
    public ICollection<Role> Roles { get; set; }

    //public ICollection<ApprovalFlowTemplate> ApprovalFlowTemplates { get; set; }

    public ICollection<ChatMessage> FromChatMessages { get; set; }
    public ICollection<ChatMessage> ToChatMessages { get; set; }

    public ICollection<Delegation> FromDelegations { get; set; }
    public ICollection<Delegation> ToDelegations { get; set; }
    
    public ICollection<Document> Documents { get; set; }
    public ICollection<DocumentAction> DocumentActions { get; set; }
}