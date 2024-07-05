namespace ProcApi.Application.DTOs.AnnualProcurement.Requests;

public class CreateAnnualProcurementItemRequest
{
    public int MaterialId { get; set; }
    public int UnitOfMeasureId { get; set; }
    public decimal Quantity { get; set; }
}