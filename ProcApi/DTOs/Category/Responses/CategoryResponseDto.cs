using ProcApi.DTOs.Category.Base;

namespace ProcApi.DTOs.Category.Responses;

public class CategoryResponseDto : CategoryDto
{
    public int ParentCategoryId { get; set; }
}