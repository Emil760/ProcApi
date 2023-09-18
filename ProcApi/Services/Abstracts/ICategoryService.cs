using ProcApi.DTOs.Category.Base;
using ProcApi.DTOs.Category.Requests;
using ProcApi.DTOs.Category.Responses;

namespace ProcApi.Services.Abstracts;

public interface ICategoryService
{
    Task<CategoryResponseDto> CreateCategory(CreateCategoryDto dto);
    Task<IEnumerable<CategoryDto>> GetByLevelAsync(int level);
}