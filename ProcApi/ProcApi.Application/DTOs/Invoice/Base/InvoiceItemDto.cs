namespace ProcApi.Application.DTOs.Invoice.Base;

public class InvoiceItemDto
{
    public int PurchaseRequestItemId { get; set; }
    public decimal Quantity { get; set; }
    public int UnitOfMeasureId { get; set; }
}