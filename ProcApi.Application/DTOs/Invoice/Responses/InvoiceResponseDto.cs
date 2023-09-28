using ProcApi.Application.DTOs.Documents.Base;
using ProcApi.Application.DTOs.Documents.Responses;
using ProcApi.Application.DTOs.Supplier.Base;

namespace ProcApi.Application.DTOs.Invoice.Responses;

public class InvoiceResponseDto : SupplierDto
{
    public string SupplierName { get; set; }
    public BaseDocumentDto BaseDocumentDto { get; set; }    
    public IEnumerable<InvoiceItemResponseDto> Items { get; set; }
    public IEnumerable<DocumentMemberResponseDto> MembersDto { get; set; }
}