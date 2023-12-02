namespace ProcApi.Domain.Entities;

public class UnitOfMeasure
{
    public int Id { get; set; }
    public string Name { get; set; }
    public ICollection<UnitOfMeasureConverter> Converters { get; set; }
}
