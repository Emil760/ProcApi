using ProcApi.Domain.Entities;
using ProcApi.Infrastructure.Data;
using ProcApi.Infrastructure.Repositories.Abstracts;

namespace ProcApi.Infrastructure.Repositories.Concreates;

public class ProjectRepository : GenericRepository<Project>, IProjectRepository
{
    public ProjectRepository(ProcDbContext context) : base(context)
    {
    }
}