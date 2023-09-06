namespace ProcApi.DTOs.PurchaseRequestDocument.Requests;

public class CreatePurchaseRequestDocumentRequestDto
{
    public IEnumerable<CreatePurchaseRequestDocumentItemRequestDto> Items { get; set; }
    public string DeliveryAddress { get; set; }
    public int DepartmentId { get; set; }
    public string Description { get; set; }
}