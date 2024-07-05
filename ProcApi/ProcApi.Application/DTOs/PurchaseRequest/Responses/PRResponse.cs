using ProcApi.Application.DTOs.Documents.Base;
using ProcApi.Application.DTOs.Documents.Responses;
using ProcApi.Application.DTOs.PurchaseRequest.Base;

namespace ProcApi.Application.DTOs.PurchaseRequest.Responses;

public class PRResponse : PRDto
{
    public BaseDocumentDto BaseDocumentDto { get; set; }
    public IEnumerable<PRItemResponse> ItemsDto { get; set; }
    public IEnumerable<DocumentMemberResponseDto> MembersDto { get; set; }
    public decimal TotalItemsPrice { get; set; }
}