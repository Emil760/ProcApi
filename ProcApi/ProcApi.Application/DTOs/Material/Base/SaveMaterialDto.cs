namespace ProcApi.Application.DTOs.Material.Base;

public class SaveMaterialDto : MaterialDto
{
    public int UnitOfMeasureId { get; set; }
    public int CategoryId { get; set; }
}