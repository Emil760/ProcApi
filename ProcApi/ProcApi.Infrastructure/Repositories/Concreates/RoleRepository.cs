using ProcApi.Domain.Entities;
using ProcApi.Infrastructure.Data;
using ProcApi.Infrastructure.Repositories.Abstracts;

namespace ProcApi.Infrastructure.Repositories.Concreates;

public class RoleRepository : GenericRepository<Role, int>, IRoleRepository
{
    public RoleRepository(ProcDbContext context) : base(context)
    {
    }
}