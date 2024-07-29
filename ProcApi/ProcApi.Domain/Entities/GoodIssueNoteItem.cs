namespace ProcApi.Domain.Entities;

public class GoodIssueNoteItem
{
    public int Id { get; set; }
    public int GoodIssueNoteId { get; set; }
    public GoodIssueNote GoodIssueNote { get; set; }
    public int MaterialId { get; set; }
    public Material Material { get; set; }
    public int UnitOfMeasureId { get; set; }
    public UnitOfMeasure UnitOfMeasure { get; set; }
    public decimal Quantity { get; set; }
    public decimal Price { get; set; }
}