using ProcApi.DTOs.Category.Base;

namespace ProcApi.DTOs.Category.Responses;

public class TreeCategoryResponseDto : CategoryDto
{
    public int Level { get; set; }
}