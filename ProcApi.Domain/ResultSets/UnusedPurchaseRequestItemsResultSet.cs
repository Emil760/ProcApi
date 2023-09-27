namespace ProcApi.Domain.ResultSets;

public class UnusedPurchaseRequestItemsResultSet
{
    public int PurchaseRequestDocumentItemId { get; set; }
    public string PurchaseRequestDocumentNumber { get; set; }
    public string MaterialName { get; set; }
    public decimal Count { get; set; }
    public decimal UnusedCount { get; set; }
}