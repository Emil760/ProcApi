namespace ProcApi.DTOs.PurchaseRequestDocument.Requests;

public class CreatePurchaseRequestDocumentRequestDto
{
    public int DocumentId { get; set; }
    public string DeliveryAddress { get; set; }
    public int DepartmentId { get; set; }
    public string Description { get; set; }
    public IEnumerable<CreatePurchaseRequestDocumentItemRequestDto> Items { get; set; }
}