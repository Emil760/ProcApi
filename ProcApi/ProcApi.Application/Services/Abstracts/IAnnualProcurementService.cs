using ProcApi.Application.DTOs.AnnualProcurement.Requests;
using ProcApi.Application.DTOs.AnnualProcurement.Responses;

namespace ProcApi.Application.Services.Abstracts;

public interface IAnnualProcurementService
{
    Task<AnnualProcurementResponseDto> CreateAnnualProcurementAsync(CreateAnnualProcurementRequestDto dto);
}