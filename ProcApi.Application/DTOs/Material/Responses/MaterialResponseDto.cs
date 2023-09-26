using ProcApi.DTOs.Material.Base;

namespace ProcApi.DTOs.Material.Responses;

public class MaterialResponseDto : MaterialDto
{
    public int Id { get; set; }
    public int CategoryId { get; set; }
    public string CategoryName { get; set; }
}