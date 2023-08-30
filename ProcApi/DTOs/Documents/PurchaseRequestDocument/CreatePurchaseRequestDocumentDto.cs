namespace ProcApi.DTOs.Documents.PurchaseRequestDocument;

public record CreatePurchaseRequestDocumentDto(
    string DeliveryAddress,
    int DepartmentId
);