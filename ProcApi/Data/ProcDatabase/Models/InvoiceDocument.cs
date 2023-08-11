using ProcApi.Data.ProcDatabase.Enums;

namespace ProcApi.Data.ProcDatabase.Models;

public class InvoiceDocument
{
    public int Id { get; set; }
    public int DocumentId { get; set; }
    public required Document Document { get; set; }
    //public int InvoiceTypeId { get; set; }
    //public InvoiceType InvoiceType { get; set; }
}