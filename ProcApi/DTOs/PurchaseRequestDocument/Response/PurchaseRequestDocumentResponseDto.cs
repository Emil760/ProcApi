using ProcApi.DTOs.Documents.Base;
using ProcApi.DTOs.Documents.Responses;

namespace ProcApi.DTOs.PurchaseRequestDocument.Response;

public record PurchaseRequestDocumentResponseDto(
    BaseDocumentDto BaseDocumentDto,
    IEnumerable<DocumentMemberResponseDto> MemberDtos
);