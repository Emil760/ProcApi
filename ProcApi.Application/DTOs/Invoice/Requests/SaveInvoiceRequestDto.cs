using ProcApi.Application.DTOs.Invoice.Base;

namespace ProcApi.Application.DTOs.Invoice.Requests;

public class SaveInvoiceRequestDto : InvoiceDto
{
    public int DocumentId { get; set; }
    public IEnumerable<CreateInvoiceItemRequestDto> Items { get; set; }
}