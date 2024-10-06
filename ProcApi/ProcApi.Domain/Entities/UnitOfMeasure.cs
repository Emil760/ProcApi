using ProcApi.Domain.Interfaces;

namespace ProcApi.Domain.Entities;

public class UnitOfMeasure : IEntity<int>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public bool CanBeDecimal { get; set; }
    public bool IsActive { get; set; }
    public ICollection<UnitOfMeasureConverter> Converters { get; set; }
}