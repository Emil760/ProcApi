using AutoMapper;
using Microsoft.Extensions.Localization;
using ProcApi.Data.ProcDatabase.Models;
using ProcApi.DTOs.Category.Base;
using ProcApi.DTOs.Category.Requests;
using ProcApi.DTOs.Category.Responses;
using ProcApi.Exceptions;
using ProcApi.Repositories.Abstracts;
using ProcApi.Resources;
using ProcApi.Services.Abstracts;

namespace ProcApi.Services.Concreates;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IStringLocalizer<SharedResource> _localizer;
    private readonly IMapper _mapper;

    public CategoryService(ICategoryRepository categoryRepository,
        IStringLocalizer<SharedResource> localizer,
        IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _localizer = localizer;
        _mapper = mapper;
    }

    public async Task<CategoryResponseDto> CreateCategory(CreateCategoryDto dto)
    {
        if (dto.ParentCategoryId is not null)
        {
            var exists = await _categoryRepository
                .ExistsByNameAndParentCategoryId(dto.ParentCategoryId.Value, dto.Name);

            if (exists)
                throw new ValidationException(_localizer["CategoryNameAlreadyUsed"]);
        }

        var category = _mapper.Map<Category>(dto);

        await _categoryRepository.InsertAsync(category);

        return _mapper.Map<CategoryResponseDto>(category);
    }

    public async Task<IEnumerable<CategoryDto>> GetByLevelAsync(int level)
    {
        var resultSet = await _categoryRepository.GetCategoriesByLevel(level);

        return _mapper.Map<IEnumerable<CategoryDto>>(resultSet);
    }
}