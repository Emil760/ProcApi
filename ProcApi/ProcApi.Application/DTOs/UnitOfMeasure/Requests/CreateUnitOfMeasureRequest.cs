namespace ProcApi.Application.DTOs.UnitOfMeasure.Requests;

public class CreateUnitOfMeasureRequest
{
    public string Name { get; set; }
    public bool CanBeDecimal { get; set; }
}