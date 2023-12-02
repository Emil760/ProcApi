using ProcApi.Application.DTOs.Supplier.Requests;
using ProcApi.Application.DTOs.Supplier.Responses;
using ProcApi.Domain.Models;

namespace ProcApi.Application.Services.Abstracts;

public interface ISupplierService
{
    Task<SupplierResponseDto> GetSupplierAsync(int id);
    Task<IEnumerable<SupplierResponseDto>> GetAllSupplierAsync(PaginationModel pagination);
    Task<SupplierResponseDto> CreateSupplierAsync(CreateSupplierRequestDto requestDto);
    Task<SupplierResponseDto> UpdateSupplierAsync(UpdateSupplierRequestDto dto);
    Task<bool> ActivateSupplier(int id, bool isActive);
}