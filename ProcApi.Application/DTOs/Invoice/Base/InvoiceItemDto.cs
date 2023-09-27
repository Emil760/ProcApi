namespace ProcApi.Application.DTOs.Invoice.Base;

public class InvoiceItemDto
{
    public int PurchaseRequestDocumentItemId { get; set; }
    public decimal Quantity { get; set; }
    public decimal Price { get; set; }
}