using ProcApi.Domain.Interfaces;

namespace ProcApi.Domain.Entities;

public class GoodReceiptNoteItem : IEntity<int>
{
    public int Id { get; set; }
    public GoodReceiptNote GoodReceiptNote { get; set; }
    public int GoodReceiptNoteId { get; set; }
    public int MaterialId { get; set; }
    public Material Material { get; set; }
    public int UnitOfMeasureId { get; set; }
    public UnitOfMeasure UnitOfMeasure { get; set; }
    public ReservedItem ReservedItem { get; set; }
    public decimal Quantity { get; set; }
    public decimal UsedQuantity { get; set; }
    public decimal Price { get; set; }
}