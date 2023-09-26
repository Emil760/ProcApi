using ProcApi.Application.DTOs.Documents.Base;
using ProcApi.Application.DTOs.Documents.Responses;
using ProcApi.DTOs.PurchaseRequestDocument.Base;

namespace ProcApi.DTOs.PurchaseRequestDocument.Response;

public class PRResponseDto : PRDto
{
    public BaseDocumentDto BaseDocumentDto { get; set; }
    public IEnumerable<PRItemResponseDto> ItemsDto { get; set; }
    public IEnumerable<DocumentMemberResponseDto> MembersDto { get; set; }
}