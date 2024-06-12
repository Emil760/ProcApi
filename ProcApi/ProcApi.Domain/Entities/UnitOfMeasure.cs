namespace ProcApi.Domain.Entities;

public class UnitOfMeasure
{
    public int Id { get; set; }
    public string Name { get; set; }
    public bool CanBeDecimal { get; set; }
    public bool IsActive { get; set; }
    public ICollection<UnitOfMeasureConverter> Converters { get; set; }
    public ICollection<Material> Materials { get; set; }
}