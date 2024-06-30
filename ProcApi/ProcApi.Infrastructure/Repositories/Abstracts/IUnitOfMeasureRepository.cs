using ProcApi.Domain.Entities;

namespace ProcApi.Infrastructure.Repositories.Abstracts;

public interface IUnitOfMeasureRepository : IGenericRepository<UnitOfMeasure>
{
    Task<IEnumerable<UnitOfMeasure?>> GetByIdsAsync(IEnumerable<int> ids);
    Task<IEnumerable<UnitOfMeasure?>> GetAllActiveAsync();
    Task<bool> ExistsAll(params int[] ids);
    Task<bool> ExistsByName(string name);
    Task<UnitOfMeasure?> GetRulesAsync(int id); 
}