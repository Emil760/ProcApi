using ProcApi.Application.DTOs.Category.Base;
using ProcApi.Application.DTOs.Category.Requests;
using ProcApi.Application.DTOs.Category.Responses;

namespace ProcApi.Application.Services.Abstracts;

public interface ICategoryService
{
    Task<CategoryResponseDto> CreateCategory(CreateCategoryDto dto);
    Task<IEnumerable<CategoryDto>> GetByLevelAsync(int level);
}