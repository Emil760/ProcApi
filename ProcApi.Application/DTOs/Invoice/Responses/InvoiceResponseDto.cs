using ProcApi.Application.DTOs.Documents.Base;
using ProcApi.Application.DTOs.Documents.Responses;

namespace ProcApi.Application.DTOs.Invoice.Responses;

public class InvoiceResponseDto
{
    public BaseDocumentDto BaseDocumentDto { get; set; }
    public IEnumerable<DocumentMemberResponseDto> MembersDto { get; set; }
}