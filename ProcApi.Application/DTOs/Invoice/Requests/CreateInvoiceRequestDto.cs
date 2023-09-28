using ProcApi.Application.DTOs.Invoice.Base;
using ProcApi.Application.DTOs.Supplier.Base;

namespace ProcApi.Application.DTOs.Invoice.Requests;

public class CreateInvoiceRequestDto : SupplierDto
{
    IEnumerable<InvoiceItemDto> Items { get; set; }
}