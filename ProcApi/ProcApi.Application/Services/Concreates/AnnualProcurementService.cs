using AutoMapper;
using Microsoft.Extensions.Localization;
using ProcApi.Application.DTOs.AnnualProcurement.Requests;
using ProcApi.Application.DTOs.AnnualProcurement.Responses;
using ProcApi.Application.Services.Abstracts;
using ProcApi.Domain.Constants;
using ProcApi.Domain.Entities;
using ProcApi.Domain.Exceptions;
using ProcApi.Infrastructure.Repositories.Abstracts;
using ProcApi.Infrastructure.Repositories.UnitOfWork;
using ProcApi.Infrastructure.Resources;

namespace ProcApi.Application.Services.Concreates;

public class AnnualProcurementService : IAnnualProcurementService
{
    private readonly IAnnualProcurementRepository _annualProcurementRepository;
    private readonly IMaterialRepository _materialRepository;
    private readonly IUnitOfMeasureRepository _unitOfMeasureRepository;
    private readonly IUnitOfMeasureService _unitOfMeasureService;
    private readonly IStringLocalizer<SharedResource> _localizer;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public AnnualProcurementService(IAnnualProcurementRepository annualProcurementRepository,
        IMaterialRepository materialRepository,
        IUnitOfMeasureRepository unitOfMeasureRepository,
        IUnitOfMeasureService unitOfMeasureService,
        IStringLocalizer<SharedResource> localizer,
        IMapper mapper,
        IUnitOfWork unitOfWork)
    {
        _annualProcurementRepository = annualProcurementRepository;
        _materialRepository = materialRepository;
        _unitOfMeasureRepository = unitOfMeasureRepository;
        _unitOfMeasureService = unitOfMeasureService;
        _localizer = localizer;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<AnnualProcurementResponseDto> CreateAnnualProcurementAsync(CreateAnnualProcurementRequestDto dto)
    {
        var isExists = await _annualProcurementRepository.ExistsByYearAsync(dto.Year);
        if (isExists)
            throw new ValidationException(_localizer[LocalizationKeys.ANNUAL_PROCUREMENT_ALREADY_EXISTS]);

        var annualProcurement = _mapper.Map<AnnualProcurement>(dto);

        await _annualProcurementRepository.InsertAsync(annualProcurement);

        return _mapper.Map<AnnualProcurementResponseDto>(annualProcurement);
    }

    public async Task ChangeAnnualProcurementAsync(int id)
    {
        var currentAnnualProcurement = await _annualProcurementRepository.GetWithItemsByIdAsync(id);
        if (currentAnnualProcurement is null)
            throw new NotFoundException(_localizer[LocalizationKeys.ANNUAL_PROCUREMENT_NOT_FOUND]);

        currentAnnualProcurement.IsActive = false;
        currentAnnualProcurement.LastUpdateDate = DateTime.Now;

        var newAnnualProcurement = new AnnualProcurement()
        {
            Name = currentAnnualProcurement.Name,
            Description = currentAnnualProcurement.Description,
            Version = (short)(currentAnnualProcurement.Version + 1),
            Year = currentAnnualProcurement.Year,
            Items = new List<AnnualProcurementItem>()
        };

        foreach (var item in currentAnnualProcurement.Items)
        {
            var newItem = (AnnualProcurementItem)item.Clone();
            _unitOfWork.MarkAdd(newItem);
            newAnnualProcurement.Items.Add(newItem);
        }

        await _annualProcurementRepository.InsertAsync(newAnnualProcurement);
    }

    public async Task ActivateAsync(int id)
    {
        var annualProcurement = await _annualProcurementRepository.GetByIdAsync(id);
        if (annualProcurement is null)
            throw new NotFoundException(_localizer[LocalizationKeys.ANNUAL_PROCUREMENT_NOT_FOUND]);

        var activeExists = await _annualProcurementRepository.ExistsByYearAndActiveAsync(annualProcurement.Year, true);
        if (activeExists)
            throw new NotFoundException(_localizer[LocalizationKeys.ACTIVE_ANNUAL_PROCUREMENT_ALREADY_EXISTS]);

        annualProcurement.IsActive = true;
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task DeactivateAsync(int id)
    {
        var annualProcurement = await _annualProcurementRepository.GetByIdAsync(id);
        if (annualProcurement is null)
            throw new NotFoundException(_localizer[LocalizationKeys.ANNUAL_PROCUREMENT_NOT_FOUND]);

        annualProcurement.IsActive = false;
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task<IEnumerable<AnnualProcurementResponseDto>> GetAllAsync()
    {
        var annualProcurements = await _annualProcurementRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<AnnualProcurementResponseDto>>(annualProcurements);
    }

    public async Task<IEnumerable<AnnualProcurementResponseDto>> GetAllActiveAsync()
    {
        var annualProcurements = await _annualProcurementRepository.GetAllActiveAsync();
        return _mapper.Map<IEnumerable<AnnualProcurementResponseDto>>(annualProcurements);
    }

    public async Task<AnnualProcurementItemResponseDto> AddItemAsync(CreateAnnualProcurementItemsRequestDto dto)
    {
        var annualProcurement = await _annualProcurementRepository.GetByIdAsync(dto.AnnualProcurementId);
        if (annualProcurement is null)
            throw new NotFoundException(_localizer[LocalizationKeys.ANNUAL_PROCUREMENT_NOT_FOUND]);

        var unitOfMeasureIds = dto.Items.Select(i => i.UnitOfMeasureId).Distinct();
        var unitOfMeasures = await _unitOfMeasureRepository.GetByIdsAsync(unitOfMeasureIds);
        if (unitOfMeasureIds.Count() != unitOfMeasures.Count())
            throw new NotFoundException(_localizer[LocalizationKeys.UNIT_OF_MEASURE_NOT_FOUND]);

        var materialsIds = dto.Items.Select(i => i.MaterialId).Distinct();
        var materials = (IEnumerable<int>)new int[] { };
        if (materialsIds.Count() != materials.Count())
            throw new NotFoundException(_localizer[LocalizationKeys.MATERIAL_NOT_FOUND]);

        var itemsException = new ItemsException<int>();
        var exceptionIds = new List<int>();

        foreach (var createItem in dto.Items)
        {
            var unitOfMeasure = unitOfMeasures.SingleOrDefault(uom => uom.Id == createItem.UnitOfMeasureId);
            
            try
            {
                _unitOfMeasureService.ValidateQuantity(unitOfMeasure, createItem.Quantity);
            }
            catch (ValidationException ex)
            {
                exceptionIds.Add(createItem.UnitOfMeasureId);
                throw;
            }
        }

        // var material = await _materialRepository.GetByIdAsync(dto.MaterialId);
        // if (material is null)
        //     throw new NotFoundException(_localizer[LocalizationKeys.MATERIAL_NOT_FOUND]);
        //
        // var unitOfMeasure = await _unitOfMeasureRepository.GetByIdAsync(dto.UnitOfMeasureId);
        // if (unitOfMeasure is null)
        //     throw new NotFoundException(_localizer[LocalizationKeys.UNIT_OF_MEASURE_NOT_FOUND]);
        // _unitOfMeasureService.ValidateQuantity(unitOfMeasure, dto.Quantity);

        return null;
    }
}