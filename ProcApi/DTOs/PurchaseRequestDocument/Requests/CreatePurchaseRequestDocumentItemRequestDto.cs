namespace ProcApi.DTOs.PurchaseRequestDocument.Requests;

public record CreatePurchaseRequestDocumentItemRequestDto(
    string Name,
    double Quantity,
    double Price,
    int UnitOfMeasureId);