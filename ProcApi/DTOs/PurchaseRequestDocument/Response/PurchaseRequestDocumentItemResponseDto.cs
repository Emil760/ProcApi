namespace ProcApi.DTOs.PurchaseRequestDocument.Response;

public class PurchaseRequestDocumentItemResponseDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public double Quantity { get; set; }
    public double Price { get; set; }
    public int UnitOfMeasureId { get; set; }
}