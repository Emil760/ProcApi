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
    private readonly IStringLocalizer<SharedResource> _localizer;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public AnnualProcurementService(IAnnualProcurementRepository annualProcurementRepository,
        IStringLocalizer<SharedResource> localizer,
        IMapper mapper,
        IUnitOfWork unitOfWork)
    {
        _annualProcurementRepository = annualProcurementRepository;
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
}