using ProcApi.Application.DTOs.Category.Base;

namespace ProcApi.Application.DTOs.Category.Responses;

public class TreeCategoryResponseDto : CategoryDto
{
    public int Level { get; set; }
}