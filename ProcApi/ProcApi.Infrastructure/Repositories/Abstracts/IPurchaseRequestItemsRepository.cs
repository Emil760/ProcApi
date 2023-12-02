using ProcApi.Domain.Entities;

namespace ProcApi.Infrastructure.Repositories.Abstracts;

public interface IPurchaseRequestItemsRepository : IGenericRepository<PurchaseRequestItem>
{
    Task<IEnumerable<PurchaseRequestItem>> GetAllByDocIdAsync(int docId);
    Task<IEnumerable<PurchaseRequestItem>> GetByIds(IEnumerable<int> itemIds);
}