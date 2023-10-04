using ProcApi.Application.Services.Abstracts;
using ProcApi.Infrastructure.Repositories.Abstracts;

namespace ProcApi.Application.Services.Concreates;

public class DepartmentService : IDepartmentService
{
    private readonly IDepartmentRepository _departmentRepository;
    
    public DepartmentService(IDepartmentRepository departmentRepository)
    {
        _departmentRepository = departmentRepository;
    }
}