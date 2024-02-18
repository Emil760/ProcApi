namespace ProcApi.Application.DTOs.UnitOfMeasure.Requests;

public class CreateUnitOfMeasureRequestDto
{
    public string Name { get; set; }
    public bool CanBeDecimal { get; set; }
}