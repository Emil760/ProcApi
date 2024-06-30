namespace ProcApi.Domain.Entities;

public class GoodReceiptNoteItem
{
    public int Id { get; set; }
    public GoodReceiptNote GoodReceiptNote { get; set; }
    public int GoodReceiptNoteId { get; set; }
}