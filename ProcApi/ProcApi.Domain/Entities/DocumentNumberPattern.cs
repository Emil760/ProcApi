using ProcApi.Domain.Enums;
using ProcApi.Domain.Interfaces;

namespace ProcApi.Domain.Entities;

public class DocumentNumberPattern : IEntity<int>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DocumentType DocumentType { get; set; }
    public DateTime CreatedDate { get; set; }
    public bool IsActive { get; set; }
    public ICollection<Document> Documents { get; set; }
    public ICollection<DocumentNumberSection> DocumentNumberSections { get; set; }
}
