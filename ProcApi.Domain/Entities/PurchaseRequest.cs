namespace ProcApi.Domain.Entities;

public class PurchaseRequest
{
    public int DocumentId { get; set; }
    public Document Document { get; set; }
    public string DeliveryAddress { get; set; }
    public string Description { get; set; }
    public int RequestedForDepartmentId { get; set; }
    public Department RequestedForDepartment { get; set; }
    public int? ProjectId { get; set; }
    public Project? Project { get; set; }
    public decimal TotalItemsPrice { get; set; }
    public ICollection<PurchaseRequestItem> Items { get; set; }
}