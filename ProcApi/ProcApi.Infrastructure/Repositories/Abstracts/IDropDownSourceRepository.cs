using ProcApi.Domain.Entities;

namespace ProcApi.Infrastructure.Repositories.Abstracts;

public interface IDropDownSourceRepository : IGenericRepository<DropDownSource>
{
    Task<bool> ExistsByKey(string key);
    Task<bool> ExistsByKeyNotThis(int id, string key);
}