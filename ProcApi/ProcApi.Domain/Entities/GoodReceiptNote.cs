namespace ProcApi.Domain.Entities;

public class GoodReceiptNote
{
    public int DocumentId { get; set; }
    public Document Document { get; set; }
    public decimal TotalItemsPrice { get; set; }
    public ICollection<GoodReceiptNoteItem> Items { get; set; }
}