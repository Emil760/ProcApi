using ProcApi.Application.DTOs.AnnualProcurement.Requests;
using ProcApi.Application.DTOs.AnnualProcurement.Responses;

namespace ProcApi.Application.Services.Abstracts;

public interface IAnnualProcurementService
{
    Task<AnnualProcurementResponseDto> CreateAnnualProcurementAsync(CreateAnnualProcurementRequest dto);
    Task ChangeAnnualProcurementAsync(int id);
    Task ActivateAsync(int id);
    Task DeactivateAsync(int id);
    Task<IEnumerable<AnnualProcurementResponseDto>> GetAllAsync();
    Task<IEnumerable<AnnualProcurementResponseDto>> GetAllActiveAsync();
    Task<AnnualProcurementItemResponseDto> AddItemAsync(CreateAnnualProcurementItemsRequest dto);
}