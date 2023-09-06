namespace ProcApi.DTOs.PurchaseRequestDocument.Requests;

public class CreatePurchaseRequestDocumentItemRequestDto
{
    public string Name { get; set; }
    public double Quantity { get; set; }
    public double Price { get; set; }
    public int UnitOfMeasureId { get; set; }
}