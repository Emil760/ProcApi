using ProcApi.Application.DTOs.Invoice.Base;

namespace ProcApi.Application.DTOs.Invoice.Responses;

public class SaveInvoiceResponseDto : InvoiceDto
{
    public IEnumerable<InvoiceItemResponseDto> Items { get; set; }
    public decimal TotalItemsPrice { get; set; }
}