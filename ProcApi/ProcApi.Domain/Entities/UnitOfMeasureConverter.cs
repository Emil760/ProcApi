namespace ProcApi.Domain.Entities;

public class UnitOfMeasureConverter
{
    public int Id { get; set; }
    public int SourceUnitOfMeasureId { get; set; }
    public UnitOfMeasure SourceUnitOfMeasure { get; set; }
    public int TargetUnitOfMeasureId { get; set; }
    public UnitOfMeasure TargetUnitOfMeasure { get; set; }
    public bool IsActive { get; set; }
    public decimal Value { get; set; }
}