using ProcApi.Application.DTOs.Supplier.Requests;
using ProcApi.Application.DTOs.Supplier.Responses;
using ProcApi.Domain.Models;

namespace ProcApi.Application.Services.Abstracts;

public interface ISupplierService
{
    Task<SupplierResponse> GetSupplierAsync(int id);
    Task<IEnumerable<SupplierResponse>> GetAllSupplierAsync(PaginationModel pagination);
    Task<SupplierResponse> CreateSupplierAsync(CreateSupplierRequest request);
    Task<SupplierResponse> UpdateSupplierAsync(UpdateSupplierRequest dto);
    Task<bool> ActivateSupplier(int id, bool isActive);
}