using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Localization;
using ProcApi.Application.DTOs;
using ProcApi.Application.DTOs.Category.Responses;
using ProcApi.Application.DTOs.Material.Base;
using ProcApi.Application.DTOs.Material.Request;
using ProcApi.Application.DTOs.Material.Responses;
using ProcApi.Application.Services.Abstracts;
using ProcApi.Domain.Entities;
using ProcApi.Domain.Exceptions;
using ProcApi.Domain.Models;
using ProcApi.Domain.Constants;
using ProcApi.Infrastructure.Repositories.Abstracts;
using ProcApi.Infrastructure.Repositories.UnitOfWork;
using ProcApi.Infrastructure.Resources;

namespace ProcApi.Application.Services.Concreates;

public class MaterialService : IMaterialService
{
    private readonly IMaterialRepository _materialRepository;
    private readonly ICategoryRepository _categoryRepository;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IStringLocalizer<SharedResource> _localizer;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public MaterialService(IMaterialRepository materialRepository,
        IHttpContextAccessor httpContextAccessor,
        ICategoryRepository categoryRepository,
        IMapper mapper,
        IStringLocalizer<SharedResource> localizer,
        IUnitOfWork unitOfWork)
    {
        _materialRepository = materialRepository;
        _httpContextAccessor = httpContextAccessor;
        _categoryRepository = categoryRepository;
        _mapper = mapper;
        _localizer = localizer;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<MaterialResponse>> GetAllAsync(PaginationModel pagination)
    {
        var materialsPaginated = await _materialRepository.GetAllPaginated(pagination);

        _httpContextAccessor.HttpContext!.Response.Headers.Append(HeaderKeys.XPagination, materialsPaginated.ToString());

        return _mapper.Map<IEnumerable<MaterialResponse>>(materialsPaginated.ResultSet);
    }

    public async Task<TreeMaterialResponse> GetAsync(int id)
    {
        var materialResultSets = (await _materialRepository.GetWithCategories(id)).ToList();

        if (materialResultSets.Count == 0)
            throw new NotFoundException(_localizer[LocalizationKeys.MATERIAL_NOT_FOUND]);

        var categories = new List<TreeCategoryResponse>();

        foreach (var item in materialResultSets)
        {
            categories.Add(new TreeCategoryResponse
            {
                Id = item.CategoryId,
                Name = item.CategoryName,
                Level = item.Level
            });
        }

        var materialResultSet = materialResultSets.First();

        var material = new TreeMaterialResponse
        {
            Id = materialResultSet.Id,
            Code = materialResultSet.Code,
            Name = materialResultSet.Name,
            TreeCategories = categories
        };

        return material;
    }

    public async Task<MaterialResponse> CreateMaterial(CreateMaterialRequest dto)
    {
        var category = await ValidateCategory(dto.CategoryId);
        await ValidateAddMaterial(dto);

        var material = _mapper.Map<Material>(dto);
        material.Category = category;

        await _materialRepository.InsertAsync(material);

        return _mapper.Map<MaterialResponse>(material);
    }

    public async Task<MaterialResponse> EditMaterial(int id, EditMaterialRequest dto)
    {
        var category = await ValidateCategory(dto.CategoryId);
        await ValidateEditMaterial(id, dto);
        
        var material = await _materialRepository.GetByIdAsync(id);
        if (material is null)
            throw new NotFoundException(_localizer[LocalizationKeys.MATERIAL_NOT_FOUND]);

        _mapper.Map(dto, material);
        material.Category = category;

        await _unitOfWork.SaveChangesAsync();

        return _mapper.Map<MaterialResponse>(material);
    }

    //TODO delete validation
    public async Task DeleteMaterial(int id)
    {
        var material = await _materialRepository.GetByIdAsync(id);

        if (material is null)
            throw new NotFoundException(_localizer[LocalizationKeys.MATERIAL_NOT_FOUND]);

        await _materialRepository.DeleteAsync(material);
    }

    public async Task<IEnumerable<DropDownDto<int>>> GetAllForDropDownAsync()
    {
        var materials = await _materialRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<DropDownDto<int>>>(materials);
    }

    private async Task<Category> ValidateCategory(int categoryId)
    {
        var category = await _categoryRepository.GetByIdAsync(categoryId);

        if (category is null)
            throw new NotFoundException(_localizer[LocalizationKeys.CATEGORY_NOT_FOUND]);

        return category;
    }

    private async Task ValidateAddMaterial(SaveMaterialDto dto)
    {
        var material = await _materialRepository.FindByCodeOrName(dto.Name, dto.Code);

        if (material is null)
            return;

        if (material.Name == dto.Name)
            throw new ValidationException(_localizer[LocalizationKeys.MANTERIAL_NAME_ALREDY_EXISTS]);

        if (material.Code == dto.Code)
            throw new ValidationException(_localizer[LocalizationKeys.MATERIAL_CODE_ALREADY_EXISTS]);
    }

    private async Task ValidateEditMaterial(int id, SaveMaterialDto dto)
    {
        var material = await _materialRepository.FindByCodeAndNameExceptCurrent(id, dto.Name, dto.Code);

        if (material is null)
            return;

        if (material.Name == dto.Name)
            throw new ValidationException(_localizer[LocalizationKeys.MANTERIAL_NAME_ALREDY_EXISTS]);

        if (material.Code == dto.Code)
            throw new ValidationException(_localizer[LocalizationKeys.MATERIAL_CODE_ALREADY_EXISTS]);
    }
}