using ProcApi.Domain.Interfaces;

namespace ProcApi.Domain.Entities;

public class InvoiceItem : IEntity<int>
{
    public int Id { get; set; }
    public int InvoiceId { get; set; }
    public Invoice Invoice { get; set; }
    public int PurchaseRequestItemId { get; set; }
    public PurchaseRequestItem PurchaseRequestItem { get; set; }
    public int UnitOfMeasureId { get; set; }
    public UnitOfMeasure UnitOfMeasure { get; set; }
    public decimal Quantity { get; set; }
    public decimal Price { get; set; }
}