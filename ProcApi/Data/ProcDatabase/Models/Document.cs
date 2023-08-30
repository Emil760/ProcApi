using ProcApi.Data.ProcDatabase.Enums;

namespace ProcApi.Data.ProcDatabase.Models;

public class Document
{
    public int Id { get; set; }
    public DocumentType DocumentTypeId { get; set; }
    public DateTime CreatedOn { get; set; }
    //public DateTime DueDate { get; set; }
    public int CreatedById { get; set; }
    public User CreatedBy { get; set; }
    public string? DocumentNumber { get; set; }
    public DocumentStatus DocumentStatusId { get; set; }
    public ICollection<DocumentAction> DocumentActions { get; set; }
    //public int PurchaseRequestDocumentId { get; set; }
    //public PurchaseRequestDocument PurchaseRequestDocument { get; set; }
}