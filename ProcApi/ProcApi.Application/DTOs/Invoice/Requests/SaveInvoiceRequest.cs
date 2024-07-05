using ProcApi.Application.DTOs.Invoice.Base;

namespace ProcApi.Application.DTOs.Invoice.Requests;

public class SaveInvoiceRequest : InvoiceDto
{
    public int DocumentId { get; set; }
    public IEnumerable<CreateInvoiceItemRequest> Items { get; set; }
}