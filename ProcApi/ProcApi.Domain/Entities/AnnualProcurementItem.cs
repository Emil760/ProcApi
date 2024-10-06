using ProcApi.Domain.Interfaces;

namespace ProcApi.Domain.Entities;

public class AnnualProcurementItem : IEntity<int>, ICloneable
{
    public int Id { get; set; }
    public int AnnualProcurementId { get; set; }
    public AnnualProcurement AnnualProcurement { get; set; }
    public int MaterialId { get; set; }
    public Material Material { get; set; }
    public int UnitOfMeasureId { get; set; }
    public UnitOfMeasure UnitOfMeasure { get; set; }
    public decimal Quantity { get; set; }

    public object Clone()
    {
        return MemberwiseClone();
    }
}