namespace ProcApi.Domain.Entities;

public class GoodReceiptNoteItem
{
    public int Id { get; set; }
    public GoodReceiptNote GoodReceiptNote { get; set; }
    public int GoodReceiptNoteId { get; set; }
    public int MaterialId { get; set; }
    public Material Material { get; set; }
    public int UnitOfMeasureId { get; set; }
    public UnitOfMeasure UnitOfMeasure { get; set; }
    public decimal Quantity { get; set; }
    public decimal Price { get; set; }
}