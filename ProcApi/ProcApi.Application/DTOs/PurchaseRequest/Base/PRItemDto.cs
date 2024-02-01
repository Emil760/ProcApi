namespace ProcApi.Application.DTOs.PurchaseRequest.Base;

public class PRItemDto
{
    public int MaterialId { get; set; }
    public double Quantity { get; set; }
    public double Price { get; set; }
    public int UnitOfMeasureId { get; set; }
}