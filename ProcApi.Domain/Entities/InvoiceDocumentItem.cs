namespace ProcApi.Domain.Entities;

public class InvoiceDocumentItem
{
    public int Id { get; set; }
    public int InvoiceDocumentId { get; set; }
    public InvoiceDocument InvoiceDocument { get; set; }
    public int PurchaseRequestDocumentItemId { get; set; }
    public PurchaseRequestDocumentItem PurchaseRequestDocumentItem { get; set; }
    public decimal Quantity { get; set; }
    public decimal Price { get; set; }
}