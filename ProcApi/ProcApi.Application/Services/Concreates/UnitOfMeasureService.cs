using AutoMapper;
using Microsoft.Extensions.Localization;
using ProcApi.Application.DTOs;
using ProcApi.Application.DTOs.UnitOfMeasure.Requests;
using ProcApi.Application.DTOs.UnitOfMeasure.Responses;
using ProcApi.Application.Services.Abstracts;
using ProcApi.Domain.Constants;
using ProcApi.Domain.Entities;
using ProcApi.Domain.Exceptions;
using ProcApi.Infrastructure.Repositories.Abstracts;
using ProcApi.Infrastructure.Repositories.UnitOfWork;
using ProcApi.Infrastructure.Resources;

namespace ProcApi.Application.Services.Concreates;

public class UnitOfMeasureService : IUnitOfMeasureService
{
    private readonly IUnitOfMeasureRepository _unitOfMeasureRepository;
    private readonly IUnitOfMeasureConverterRepository _unitOfMeasureConverterRepository;
    private readonly IMapper _mapper;
    private readonly IStringLocalizer<SharedResource> _localizer;
    private readonly IUnitOfWork _unitOfWork;

    public UnitOfMeasureService(IUnitOfMeasureRepository unitOfMeasureRepository,
        IUnitOfMeasureConverterRepository unitOfMeasureConverterRepository,
        IMapper mapper,
        IStringLocalizer<SharedResource> localizer,
        IUnitOfWork unitOfWork)
    {
        _unitOfMeasureRepository = unitOfMeasureRepository;
        _unitOfMeasureConverterRepository = unitOfMeasureConverterRepository;
        _mapper = mapper;
        _localizer = localizer;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<UnitOfMeasureResponse>> GetAllAsync()
    {
        var data = await _unitOfMeasureRepository.GetAllAsync();

        return _mapper.Map<IEnumerable<UnitOfMeasureResponse>>(data);
    }

    public async Task<IEnumerable<DropDownDto<int>>> GetActiveForDropDownAsync()
    {
        var data = await _unitOfMeasureRepository.GetAllActiveAsync();

        return _mapper.Map<IEnumerable<DropDownDto<int>>>(data);
    }

    public async Task<IEnumerable<DropDownDto<int>>> GetForDropDownAsync()
    {
        var data = await _unitOfMeasureRepository.GetAllAsync();

        return _mapper.Map<IEnumerable<DropDownDto<int>>>(data);
    }

    public async Task<UnitOfMeasureResponse> CreateAsync(CreateUnitOfMeasureRequest dto)
    {
        var exists = await _unitOfMeasureRepository.ExistsByName(dto.Name);
        if (exists)
            throw new ValidationException(_localizer[LocalizationKeys.UNIT_OF_MEASURE_NAME_ALREADY_EXISTS]);

        var unitOfMeasure = new UnitOfMeasure()
        {
            Name = dto.Name,
            CanBeDecimal = dto.CanBeDecimal,
        };

        await _unitOfMeasureRepository.InsertAsync(unitOfMeasure);

        return _mapper.Map<UnitOfMeasureResponse>(unitOfMeasure);
    }

    public async Task ActivateAsync(ActivateUnitOfMeasureRequest dto)
    {
        var unitOfMeasure = await _unitOfMeasureRepository.GetByIdAsync(dto.Id);
        if (unitOfMeasure is null)
            throw new NotFoundException(_localizer[LocalizationKeys.UNIT_OF_MEASURE_NOT_FOUND]);

        unitOfMeasure.IsActive = dto.IsActivate;

        await _unitOfWork.SaveChangesAsync();
    }

    public async Task CreateConversationRuleAsync(CreateUnitOfMeasureConversationRuleRequest dto)
    {
        var unitOfMeasures = await _unitOfMeasureRepository.GetByIdsAsync(
            new[] { dto.SourceUnitOfMeasureId, dto.TargetUnitOfMeasureId });
        if (unitOfMeasures.Count() < 2)
            throw new NotFoundException(_localizer[LocalizationKeys.UNIT_OF_MEASURE_NOT_FOUND]);

        var alreadyHasRule = await _unitOfMeasureConverterRepository.ExistsBySourceAndTargetId(
            dto.SourceUnitOfMeasureId, dto.TargetUnitOfMeasureId);
        if (alreadyHasRule)
            throw new ValidationException(_localizer[LocalizationKeys.UNIT_OF_MEASURE_ALREADY_EXISTS]);

        ValidateQuantity(unitOfMeasures.ElementAt(0), dto.Value);
        ValidateQuantity(unitOfMeasures.ElementAt(1), dto.Value);
        
        _unitOfMeasureConverterRepository.Insert(new UnitOfMeasureConverter()
        {
            SourceUnitOfMeasureId = dto.SourceUnitOfMeasureId,
            TargetUnitOfMeasureId = dto.TargetUnitOfMeasureId,
            Value = dto.Value,
        });

        _unitOfMeasureConverterRepository.Insert(new UnitOfMeasureConverter()
        {
            SourceUnitOfMeasureId = dto.TargetUnitOfMeasureId,
            TargetUnitOfMeasureId = dto.SourceUnitOfMeasureId,
            Value = 1 / dto.Value,
        });

        await _unitOfWork.SaveChangesAsync();
    }

    public async Task<IEnumerable<UnitOfMeasureConverterResponse>> GetRulesAsync(int id)
    {
        var unitOfMeasure = await _unitOfMeasureRepository.GetRulesAsync(id);

        if (unitOfMeasure is null)
            throw new NotFoundException(_localizer[LocalizationKeys.UNIT_OF_MEASURE_NOT_FOUND]);

        return _mapper.Map<IEnumerable<UnitOfMeasureConverterResponse>>(unitOfMeasure.Converters);
    }

    public void ValidateQuantity(UnitOfMeasure unitOfMeasure, decimal quantity)
    {
        if(!unitOfMeasure.CanBeDecimal && !decimal.IsInteger(quantity))
            throw new ValidationException(_localizer[LocalizationKeys.CANT_USE_DECIMAL_FOR_UNIT_OF_MEASURE]);
    }
}