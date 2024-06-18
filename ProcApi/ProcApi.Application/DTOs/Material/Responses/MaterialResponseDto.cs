using ProcApi.Application.DTOs.Material.Base;

namespace ProcApi.Application.DTOs.Material.Responses;

public class MaterialResponseDto : MaterialDto
{
    public int Id { get; set; }
    public int CategoryId { get; set; }
    public string CategoryName { get; set; }
    public int UnitOfMeasureId { get; set; }
    public string UnitOfMeasureName { get; set; }
}