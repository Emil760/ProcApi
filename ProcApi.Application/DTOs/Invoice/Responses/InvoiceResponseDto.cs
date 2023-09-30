using ProcApi.Application.DTOs.Documents.Base;
using ProcApi.Application.DTOs.Documents.Responses;
using ProcApi.Application.DTOs.Invoice.Base;

namespace ProcApi.Application.DTOs.Invoice.Responses;

public class InvoiceResponseDto : InvoiceDto
{
    public BaseDocumentDto BaseDocumentDto { get; set; }
    public IEnumerable<InvoiceItemResponseDto> ItemsDto { get; set; }
    public IEnumerable<DocumentMemberResponseDto> MembersDto { get; set; }
    public decimal TotalItemsPrice { get; set; }
}