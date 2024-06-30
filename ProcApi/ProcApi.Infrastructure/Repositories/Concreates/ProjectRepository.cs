using Microsoft.EntityFrameworkCore;
using ProcApi.Domain.Entities;
using ProcApi.Infrastructure.Data;
using ProcApi.Infrastructure.Repositories.Abstracts;

namespace ProcApi.Infrastructure.Repositories.Concreates;

public class ProjectRepository : GenericRepository<Project>, IProjectRepository
{
    public ProjectRepository(ProcDbContext context) : base(context)
    {
    }

    public async Task<bool> ExistsByNameAsync(string name)
    {
        return await _context.Projects
            .AnyAsync(p => p.Name == name);
    }

    public async Task<bool> ExistsByNameExceptCurrentAsync(int id, string name)
    {
        return await _context.Projects
            .AnyAsync(p => p.Id != id && p.Name == name);
    }
}