using ProcApi.Domain.Interfaces;

namespace ProcApi.Domain.Entities;

public class Invoice : IEntity<int>
{
    public int Id { get; set; }
    public Document Document { get; set; }
    public string? Description { get; set; }
    public int? SupplierId { get; set; }
    public Supplier? Supplier { get; set; }
    public decimal TotalItemsPrice { get; set; }
    public ICollection<InvoiceItem> Items { get; set; }
}