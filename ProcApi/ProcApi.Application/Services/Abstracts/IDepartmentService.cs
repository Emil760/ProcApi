using ProcApi.Application.DTOs.Department.Requests;
using ProcApi.Application.DTOs.Department.Responses;
using ProcApi.Domain.Models;

namespace ProcApi.Application.Services.Abstracts;

public interface IDepartmentService
{
    Task<DepartmentResponseDto> CreateDepartmentAsync(CreateDepartmentDto dto);
    Task<IEnumerable<DepartmentListResponseDto>> GetAllAsync(PaginationModel pagination);
    Task AssignUserToDepartment(int userId, AssignUserDepartmentDto dto);
}