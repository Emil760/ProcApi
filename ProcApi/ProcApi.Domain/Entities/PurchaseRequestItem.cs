using ProcApi.Domain.Enums;

namespace ProcApi.Domain.Entities;

public class PurchaseRequestItem
{
    public int Id { get; set; }
    public int PurchaseRequestId { get; set; }
    public PurchaseRequest PurchaseRequest { get; set; }
    public int MaterialId { get; set; }
    public Material Material { get; set; }
    public int UnitOfMeasureId { get; set; }
    public UnitOfMeasure UnitOfMeasure { get; set; }
    public decimal Quantity { get; set; }
    public decimal Price { get; set; }
    public ItemStatus ItemStatusId { get; set; }
    public int? BuyerId { get; set; }
    public User? Buyer { get; set; }
}