using ProcApi.Application.DTOs.Department.Requests;
using ProcApi.Application.DTOs.Department.Responses;
using ProcApi.Domain.Models;

namespace ProcApi.Application.Services.Abstracts;

public interface IDepartmentService
{
    Task<DepartmentResponse> CreateDepartmentAsync(CreateDepartmentRequest request);
    Task<IEnumerable<DepartmentListResponse>> GetAllAsync(PaginationModel pagination);
}