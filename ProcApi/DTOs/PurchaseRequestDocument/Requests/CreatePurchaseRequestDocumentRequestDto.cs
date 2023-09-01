namespace ProcApi.DTOs.PurchaseRequestDocument.Requests;

public record CreatePurchaseRequestDocumentRequestDto(
    IEnumerable<CreatePurchaseRequestDocumentItemRequestDto> Items,
    string DeliveryAddress,
    int DepartmentId,
    string Description
);