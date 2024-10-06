using ProcApi.Domain.Entities;

namespace ProcApi.Infrastructure.Repositories.Abstracts;

public interface IProjectRepository : IGenericRepository<Project, int>
{
    Task<bool> ExistsByNameAsync(string name);
    Task<bool> ExistsByNameExceptCurrentAsync(int id, string name);
}