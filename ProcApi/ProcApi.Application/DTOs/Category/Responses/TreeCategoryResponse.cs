using ProcApi.Application.DTOs.Category.Base;

namespace ProcApi.Application.DTOs.Category.Responses;

public class TreeCategoryResponse : CategoryDto
{
    public int Level { get; set; }
}