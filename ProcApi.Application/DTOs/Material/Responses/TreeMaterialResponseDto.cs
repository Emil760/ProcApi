using ProcApi.Application.DTOs.Category.Responses;
using ProcApi.Application.DTOs.Material.Base;

namespace ProcApi.Application.DTOs.Material.Responses;

public class TreeMaterialResponseDto : MaterialDto
{
    public int Id { get; set; }
    public IEnumerable<TreeCategoryResponseDto> TreeCategories { get; set; }
}