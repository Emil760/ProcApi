using ProcApi.Domain.Interfaces;

namespace ProcApi.Domain.Entities;

public class GoodReceiptNote : IEntity<int>
{
    public int Id { get; set; }
    public Document Document { get; set; }
    public decimal TotalItemsPrice { get; set; }
    public ICollection<GoodReceiptNoteItem> Items { get; set; }
}