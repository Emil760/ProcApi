using ProcApi.Application.DTOs.Department.Requests;
using ProcApi.Application.DTOs.Department.Responses;
using ProcApi.Domain.Entities;

namespace ProcApi.Application.Mappers;

public class DepartmentProfile : CommonProfile
{
    public DepartmentProfile()
    {
        CreateMap<CreateDepartmentDto, Department>();

        CreateMap<Department, DepartmentResponseDto>();
    }
}