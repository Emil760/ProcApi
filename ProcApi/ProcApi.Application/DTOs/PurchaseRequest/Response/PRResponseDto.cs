using ProcApi.Application.DTOs.Documents.Base;
using ProcApi.Application.DTOs.Documents.Responses;
using ProcApi.Application.DTOs.PurchaseRequest.Base;

namespace ProcApi.Application.DTOs.PurchaseRequest.Response;

public class PRResponseDto : PRDto
{
    public BaseDocumentDto BaseDocumentDto { get; set; }
    public IEnumerable<PRItemResponseDto> ItemsDto { get; set; }
    public IEnumerable<DocumentMemberResponseDto> MembersDto { get; set; }
    public decimal TotalItemsPrice { get; set; }
}