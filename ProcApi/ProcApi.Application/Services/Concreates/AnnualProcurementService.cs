using AutoMapper;
using Microsoft.Extensions.Localization;
using ProcApi.Application.DTOs.AnnualProcurement.Requests;
using ProcApi.Application.DTOs.AnnualProcurement.Responses;
using ProcApi.Application.Services.Abstracts;
using ProcApi.Domain.Constants;
using ProcApi.Domain.Entities;
using ProcApi.Domain.Exceptions;
using ProcApi.Infrastructure.Repositories.Abstracts;
using ProcApi.Infrastructure.Resources;

namespace ProcApi.Application.Services.Concreates;

public class AnnualProcurementService : IAnnualProcurementService
{
    private readonly IAnnualProcurementRepository _annualProcurementRepository;
    private readonly IStringLocalizer<SharedResource> _localizer;
    private readonly IMapper _mapper;

    public AnnualProcurementService(IAnnualProcurementRepository annualProcurementRepository,
        IStringLocalizer<SharedResource> localizer,
        IMapper mapper)
    {
        _annualProcurementRepository = annualProcurementRepository;
        _localizer = localizer;
        _mapper = mapper;
    }

    public async Task<AnnualProcurementResponseDto> CreateAnnualProcurementAsync(CreateAnnualProcurementRequestDto dto)
    {
        var isExists = await _annualProcurementRepository.ExistsByYear(dto.Year);
        if (isExists)
            throw new ValidationException(_localizer[LocalizationKeys.ANNUAL_PROCUREMENT_ALREADY_EXISTS]);

        var annualProcurement = _mapper.Map<AnnualProcurement>(dto);

        await _annualProcurementRepository.InsertAsync(annualProcurement);

        return _mapper.Map<AnnualProcurementResponseDto>(annualProcurement);
    }
}