using ProcApi.Domain.Enums;
using ProcApi.Domain.Interfaces;

namespace ProcApi.Domain.Entities;

public class ApprovalFlowTemplate : IEntity<int>
{
    public int Id { get; set; }
    public DocumentType DocumentTypeId { get; set; }
    public float Order { get; set; }
    public int RoleId { get; set; }
    public Role Role { get; set; }
    public int? UserId { get; set; }
    public User? User { get; set; }
    public string FlowCode { get; set; }
    public bool IsInitial { get; set; }
    public bool IsCreator { get; set; }
    public bool IsMultiple { get; set; }
}