namespace ProcApi.Application.DTOs.Invoice.Requests;

public class ChangeUnitOfMeasureItemRequest
{
    public int ItemId { get; set; }
    public int UnitOfMeasureId { get; set; }
}