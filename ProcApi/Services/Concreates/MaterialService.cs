using AutoMapper;
using Microsoft.Extensions.Localization;
using ProcApi.Constants;
using ProcApi.Data.ProcDatabase.Models;
using ProcApi.DTOs.Base;
using ProcApi.DTOs.Category.Responses;
using ProcApi.DTOs.Material.Base;
using ProcApi.DTOs.Material.Request;
using ProcApi.DTOs.Material.Responses;
using ProcApi.Exceptions;
using ProcApi.Repositories.Abstracts;
using ProcApi.Resources;
using ProcApi.Services.Abstracts;

namespace ProcApi.Services.Concreates;

public class MaterialService : IMaterialService
{
    private readonly IMaterialRepository _materialRepository;
    private readonly ICategoryRepository _categoryRepository;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IStringLocalizer<SharedResource> _localizer;
    private readonly IMapper _mapper;

    public MaterialService(IMaterialRepository materialRepository,
        IHttpContextAccessor httpContextAccessor,
        ICategoryRepository categoryRepository,
        IMapper mapper,
        IStringLocalizer<SharedResource> localizer)
    {
        _materialRepository = materialRepository;
        _httpContextAccessor = httpContextAccessor;
        _categoryRepository = categoryRepository;
        _mapper = mapper;
        _localizer = localizer;
    }

    public async Task<IEnumerable<MaterialResponseDto>> GetAllAsync(PaginationRequestDto dto)
    {
        var materialsPaginated = await _materialRepository.GetAllPaginated(dto);

        _httpContextAccessor.HttpContext.Response.Headers.Add(HeaderKeys.XPagination, materialsPaginated.ToString());

        return _mapper.Map<IEnumerable<MaterialResponseDto>>(materialsPaginated.ResultSet);
    }

    public async Task<TreeMaterialResponseDto> GetAsync(int id)
    {
        var materialResultSets = (await _materialRepository.GetWithCategories(id)).ToList();

        if (!materialResultSets.Any())
            throw new NotFoundException(_localizer["MaterialNotFound"]);

        var categories = new List<TreeCategoryResponseDto>();

        foreach (var item in materialResultSets)
        {
            categories.Add(new TreeCategoryResponseDto()
            {
                Id = item.CategoryId,
                Name = item.CategoryName,
                Level = item.Level
            });
        }

        var materialResultSet = materialResultSets.First();

        var material = new TreeMaterialResponseDto()
        {
            Id = materialResultSet.Id,
            Code = materialResultSet.Code,
            Name = materialResultSet.Name,
            TreeCategories = categories
        };

        return material;
    }

    public async Task<MaterialResponseDto> CreateMaterial(CreateMaterialRequestDto dto)
    {
        var category = await ValidateCategory(dto.CategoryId);
        await ValidateAddMaterial(dto);

        var material = _mapper.Map<Material>(dto);
        material.Category = category;

        await _materialRepository.InsertAsync(material);

        return _mapper.Map<MaterialResponseDto>(material);
    }

    public async Task<MaterialResponseDto> EditMaterial(int id, EditMaterialRequestDto dto)
    {
        var category = await ValidateCategory(dto.CategoryId);
        await ValidateEditMaterial(id, dto);

        var material = await _materialRepository.GetByIdAsync(id);

        if (material is null)
            throw new NotFoundException(_localizer["MaterialNotFound"]);

        _mapper.Map(dto, material);
        material.Category = category;

        await _materialRepository.InsertAsync(material);

        return _mapper.Map<MaterialResponseDto>(material);
    }

    public async Task DeleteMaterial(int id)
    {
        var material = await _materialRepository.GetByIdAsync(id);

        if (material is null)
            throw new NotFoundException(_localizer["MaterialNotFound"]);

        await _materialRepository.DeleteByIdAsync(material);
    }

    private async Task<Category> ValidateCategory(int categoryId)
    {
        var category = await _categoryRepository.GetByIdAsync(categoryId);

        if (category is null)
            throw new NotFoundException(_localizer["CategoryNotFound"]);

        return category;
    }

    private async Task ValidateAddMaterial(SaveMaterialDto dto)
    {
        var material = await _materialRepository.FindByCodeOrName(dto.Name, dto.Code);

        if (material is null)
            return;

        if (material.Name == dto.Name)
            throw new ValidationException(_localizer["MaterialNameAlreadyExists"]);

        if (material.Code == dto.Code)
            throw new ValidationException(_localizer["MaterialCodeAlreadyExists"]);
    }

    private async Task ValidateEditMaterial(int id, SaveMaterialDto dto)
    {
        var material = await _materialRepository.FindByCodeAndNameExceptCurrent(id, dto.Name, dto.Code);

        if (material is null)
            return;

        if (material.Name == dto.Name)
            throw new ValidationException(_localizer["MaterialNameAlreadyExists"]);

        if (material.Code == dto.Code)
            throw new ValidationException(_localizer["MaterialCodeAlreadyExists"]);
    }
}