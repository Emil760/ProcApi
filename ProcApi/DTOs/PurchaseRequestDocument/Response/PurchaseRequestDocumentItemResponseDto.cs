namespace ProcApi.DTOs.PurchaseRequestDocument.Response;

public record PurchaseRequestDocumentItemResponseDto(
    int Id,
    string Name,
    double Quantity,
    double Price
);