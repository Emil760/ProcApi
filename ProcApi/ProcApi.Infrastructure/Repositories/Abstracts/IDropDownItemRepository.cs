using ProcApi.Domain.Entities;

namespace ProcApi.Infrastructure.Repositories.Abstracts;

public interface IDropDownItemRepository : IGenericRepository<DropDownItem>
{
    Task<bool> ExistsByKeyNotThis(int id, int sourceId, string value);
}