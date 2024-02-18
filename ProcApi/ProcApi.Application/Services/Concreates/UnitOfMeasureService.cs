using AutoMapper;
using Microsoft.Extensions.Localization;
using ProcApi.Application.DTOs;
using ProcApi.Application.DTOs.UnitOfMeasure.Requests;
using ProcApi.Application.DTOs.UnitOfMeasure.Responses;
using ProcApi.Application.Services.Abstracts;
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

    public async Task<IEnumerable<UnitOfMeasureResponseDto>> GetAllAsync()
    {
        var data = await _unitOfMeasureRepository.GetAllAsync();

        return _mapper.Map<IEnumerable<UnitOfMeasureResponseDto>>(data);
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

    public async Task<UnitOfMeasureResponseDto> CreateAsync(CreateUnitOfMeasureRequestDto dto)
    {
        var exists = await _unitOfMeasureRepository.ExistsByName(dto.Name);
        if (exists)
            throw new ValidationException(_localizer["UnitOfMeasureAlreadyExistsByName"]);

        var unitOfMeasure = new UnitOfMeasure()
        {
            Name = dto.Name,
            CanBeDecimal = dto.CanBeDecimal,
        };

        await _unitOfMeasureRepository.InsertAsync(unitOfMeasure);

        return _mapper.Map<UnitOfMeasureResponseDto>(unitOfMeasure);
    }

    public async Task ActivateAsync(ActivateUnitOfMeasureRequestDto dto)
    {
        var unitOfMeasure = await _unitOfMeasureRepository.GetByIdAsync(dto.Id);
        if (unitOfMeasure is null)
            throw new NotFoundException(_localizer["UnitOfMeasureNotFound"]);

        unitOfMeasure.IsActive = dto.IsActivate;

        await _unitOfWork.SaveChangesAsync();
    }

    public async Task CreateConversationRuleAsync(CreateUnitOfMeasureConversationRuleRequestDto dto)
    {
        var unitOfMeasures = await _unitOfMeasureRepository.GetByIds(
            new[] { dto.SourceUnitOfMeasureId, dto.TargetUnitOfMeasureId });
        if (unitOfMeasures.Count() < 2)
            throw new NotFoundException(_localizer["UnitOfMeasureNotFound"]);

        var alreadyHasRule = await _unitOfMeasureConverterRepository.ExistsBySourceAndTargetId(
            dto.SourceUnitOfMeasureId, dto.TargetUnitOfMeasureId);
        if (alreadyHasRule)
            throw new ValidationException(_localizer["UnitOfMeasureAlreadyExists"]);

        if ((!unitOfMeasures.ElementAt(0).CanBeDecimal || !unitOfMeasures.ElementAt(0).CanBeDecimal) &&
            !decimal.IsInteger(dto.Value))
            throw new ValidationException(_localizer["CantUseDecimalForUnitOfMeasure"]);

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

    public async Task<IEnumerable<UnitOfMeasureConverterResponseDto>> GetRulesAsync(int id)
    {
        var unitOfMeasure = await _unitOfMeasureRepository.GetRulesAsync(id);

        if (unitOfMeasure is null)
            throw new NotFoundException(_localizer["UnitOfMeasureNotFound"]);

        return _mapper.Map<IEnumerable<UnitOfMeasureConverterResponseDto>>(unitOfMeasure.Converters);
    }
}