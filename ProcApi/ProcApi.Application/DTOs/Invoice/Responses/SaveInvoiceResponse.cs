using ProcApi.Application.DTOs.Invoice.Base;

namespace ProcApi.Application.DTOs.Invoice.Responses;

public class SaveInvoiceResponse : InvoiceDto
{
    public IEnumerable<InvoiceItemResponse> Items { get; set; }
    public decimal TotalItemsPrice { get; set; }
}