namespace ProcApi.Application.DTOs.AnnualProcurement.Requests;

public class CreateAnnualProcurementItemRequestDto
{
    public int MaterialId { get; set; }
    public int UnitOfMeasureId { get; set; }
    public decimal Quantity { get; set; }
}