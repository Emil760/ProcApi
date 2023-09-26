using ProcApi.Domain.Enums;

namespace ProcApi.Domain.Entities;

public class ApprovalFlowTemplate
{
    public int Id { get; set; }
    public DocumentType DocumentTypeId { get; set; }
    public int Order { get; set; }
    public int RoleId { get; set; }
    public Role Role { get; set; }
    public int? UserId { get; set; }
    public User? User { get; set; }
    public bool IsInitial { get; set; }
    public bool IsCreator { get; set; }
}