using ProcApi.Application.DTOs.Category.Base;
using ProcApi.Application.DTOs.Category.Requests;
using ProcApi.Application.DTOs.Category.Responses;

namespace ProcApi.Application.Services.Abstracts;

public interface ICategoryService
{
    Task<CategoryResponse> CreateCategory(CreateCategoryRequest request);
    Task<IEnumerable<CategoryDto>> GetByLevelAsync(int level);
}