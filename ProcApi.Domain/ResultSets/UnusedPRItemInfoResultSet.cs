namespace ProcApi.Domain.ResultSets;

public class UnusedPRItemInfoResultSet
{
    public int PurchaseRequestItemId { get; set; }
    public string PurchaseRequestNumber { get; set; }
    public string MaterialName { get; set; }
    public decimal Count { get; set; }
    public decimal UnusedCount { get; set; }
}