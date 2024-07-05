namespace ProcApi.Application.DTOs.UnitOfMeasure.Responses;

public class UnitOfMeasureResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public bool CanBeDecimal { get; set; }
    public bool IsActive { get; set; }
}