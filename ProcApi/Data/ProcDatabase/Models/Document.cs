using ProcApi.Data.ProcDatabase.Enums;

namespace ProcApi.Data.ProcDatabase.Models;

public class Document
{
    public int Id { get; set; }
    public int DocumentTypeId { get; set; }
    public DocumentType DocumentType { get; set; }
    public DateTime CreatedOn { get; set; }
    public int CreatedById { get; set; }
    public User CreatedBy { get; set; }
    public string DocumentNumber { get; set; }
    public int DocumentStatusId { get; set; }
    public DocumentStatus DocumentStatus { get; set; }
}