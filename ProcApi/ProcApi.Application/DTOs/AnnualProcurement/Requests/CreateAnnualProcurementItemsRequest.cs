namespace ProcApi.Application.DTOs.AnnualProcurement.Requests;

public class CreateAnnualProcurementItemsRequest
{
    public int AnnualProcurementId { get; set; }
    public IEnumerable<CreateAnnualProcurementItemRequest> Items { get; set; }
}