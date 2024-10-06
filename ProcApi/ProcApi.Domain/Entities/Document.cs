using ProcApi.Domain.Enums;
using ProcApi.Domain.Interfaces;

namespace ProcApi.Domain.Entities;

public class Document : IEntity<int>
{
    public int Id { get; set; }
    public DocumentType DocumentTypeId { get; set; }
    public DateTime CreatedOn { get; set; }
    public int CreatedById { get; set; }
    public User CreatedBy { get; set; }
    public string? Number { get; set; }
    public DocumentStatus DocumentStatusId { get; set; }
    public string FlowCodes { get; set; }
    public ICollection<DocumentAction> Actions { get; set; }
    public ICollection<Comment> Comments { get; set; }
}