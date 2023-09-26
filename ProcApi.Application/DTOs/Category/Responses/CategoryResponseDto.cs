using ProcApi.Application.DTOs.Category.Base;

namespace ProcApi.Application.DTOs.Category.Responses;

public class CategoryResponseDto : CategoryDto
{
    public int ParentCategoryId { get; set; }
}