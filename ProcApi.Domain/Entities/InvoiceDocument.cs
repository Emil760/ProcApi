namespace ProcApi.Domain.Entities;

public class InvoiceDocument
{
    public int Id { get; set; }
    public int DocumentId { get; set; }
    public Document Document { get; set; }
    //public int InvoiceTypeId { get; set; }
    //public InvoiceType InvoiceType { get; set; }
}