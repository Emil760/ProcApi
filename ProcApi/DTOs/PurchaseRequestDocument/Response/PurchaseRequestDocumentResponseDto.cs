using ProcApi.DTOs.Documents.Base;
using ProcApi.DTOs.Documents.Responses;

namespace ProcApi.DTOs.PurchaseRequestDocument.Response;

public class PurchaseRequestDocumentResponseDto
{
    public BaseDocumentDto BaseDocumentDto { get; set; }
    public IEnumerable<PurchaseRequestDocumentItemResponseDto> ItemsDto { get; set; }
    public IEnumerable<DocumentMemberResponseDto> MembersDto { get; set; }
}