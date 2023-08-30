namespace ProcApi.DTOs.Documents.PurchaseRequestDocument;

public record PurchaseRequestDocumentDto(
    BaseDocumentDto DocumentDto,
    IEnumerable<DocumentMemberDto> MemberDtos
);