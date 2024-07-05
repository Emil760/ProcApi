using AutoMapper;
using Microsoft.Extensions.Localization;
using ProcApi.Application.DTOs.DropDown.Requests;
using ProcApi.Application.DTOs.DropDown.Responses;
using ProcApi.Application.Services.Abstracts;
using ProcApi.Domain.Constants;
using ProcApi.Domain.Entities;
using ProcApi.Domain.Exceptions;
using ProcApi.Infrastructure.Repositories.Abstracts;
using ProcApi.Infrastructure.Repositories.UnitOfWork;
using ProcApi.Infrastructure.Resources;

namespace ProcApi.Application.Services.Concreates;

public class DropDownService : IDropDownService
{
    private readonly IDropDownSourceRepository _dropDownSourceRepository;
    private readonly IDropDownItemRepository _dropDownItemRepository;
    private readonly IMapper _mapper;
    private readonly IStringLocalizer<SharedResource> _localizer;
    private readonly IUnitOfWork _unitOfWork;

    public DropDownService(IDropDownSourceRepository dropDownSourceRepository,
        IDropDownItemRepository dropDownItemRepository,
        IMapper mapper,
        IUnitOfWork unitOfWork,
        IStringLocalizer<SharedResource> localizer)
    {
        _dropDownSourceRepository = dropDownSourceRepository;
        _dropDownItemRepository = dropDownItemRepository;
        _mapper = mapper;
        _localizer = localizer;
        _unitOfWork = unitOfWork;
    }

    public async Task<DropDownSourceResponse> CreateSourceAsync(CreateDropDownSourceRequest dto)
    {
        var exists = await _dropDownSourceRepository.ExistsByKey(dto.Key);
        if (exists)
            throw new ValidationException(_localizer[LocalizationKeys.DROP_DOWN_SOURCE_NAME_ALREADY_EXISTS]);

        var entity = _mapper.Map<DropDownSource>(dto);
        await _dropDownSourceRepository.InsertAsync(entity);
        return _mapper.Map<DropDownSourceResponse>(entity);
    }

    public async Task<DropDownItemResponse> CreateItemAsync(CreateDropDownItemRequest dto)
    {
        var source = await _dropDownSourceRepository.GetByIdAsync(dto.DropDownSourceId);
        if (source is null)
            throw new NotFoundException(_localizer[LocalizationKeys.DROP_DOWN_SOURCE_NOT_FOUND]);
        
        var exists = await _dropDownItemRepository.ExistsByKey(source.Id, dto.Value);
        if (exists)
            throw new ValidationException(_localizer[LocalizationKeys.DROP_DOWN_ITEM_NAME_ALREADY_EXISTS]);

        var item = _mapper.Map<DropDownItem>(dto);
        item.DropDownSource = source;
        await _dropDownItemRepository.InsertAsync(item);
        return _mapper.Map<DropDownItemResponse>(item);
    }

    public async Task ChangeSourceAsync(ChangeDropDownSourceRequest dto)
    {
        var entity = _dropDownSourceRepository.GetByIdAsync(dto.Id);
        if (entity is null)
            throw new NotFoundException(_localizer[LocalizationKeys.DROP_DOWN_SOURCE_NOT_FOUND]);

        var exists = await _dropDownSourceRepository.ExistsByKeyNotThis(dto.Id, dto.Key);
        if (exists)
            throw new ValidationException(_localizer[LocalizationKeys.DROP_DOWN_SOURCE_NAME_ALREADY_EXISTS]);

        _mapper.Map(entity, dto);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task ChangeItemAsync(ChangeDropDownItemRequest dto)
    {
        var entity = await _dropDownItemRepository.GetByIdAsync(dto.Id);
        if (entity is null)
            throw new NotFoundException(_localizer[LocalizationKeys.DROP_DOWN_ITEM_SOURCE_NOT_FOUND]);

        var exists = await _dropDownItemRepository.ExistsByKeyNotThis(entity.Id, entity.DropDownSourceId, dto.Value);
        if (exists)
            throw new ValidationException(_localizer[LocalizationKeys.DROP_DOWN_ITEM_NAME_ALREADY_EXISTS]);

        _mapper.Map(entity, dto);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task<IEnumerable<DropDownSourceResponse>> GetAllSources()
    {
        var items = await _dropDownSourceRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<DropDownSourceResponse>>(items);
    }

    public async Task<IEnumerable<DropDownItemResponse>> GetAllItems(int sourceId)
    {
        var items = await _dropDownItemRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<DropDownItemResponse>>(items);
    }
}