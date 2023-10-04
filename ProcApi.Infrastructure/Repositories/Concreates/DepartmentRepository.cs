using ProcApi.Domain.Entities;
using ProcApi.Infrastructure.Data;
using ProcApi.Infrastructure.Repositories.Abstracts;

namespace ProcApi.Infrastructure.Repositories.Concreates;

public class DepartmentRepository : GenericRepository<Department>, IDepartmentRepository
{
    public DepartmentRepository(ProcDbContext context) : base(context)
    {
    }
}