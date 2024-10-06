using ProcApi.Domain.Entities;
using ProcApi.Domain.Models;
using ProcApi.Infrastructure.Utility;

namespace ProcApi.Infrastructure.Repositories.Abstracts;

public interface IGoodReceiptNoteItemRepository : IGenericRepository<GoodReceiptNoteItem, int>
{
    Task<Paginator<GoodReceiptNoteItem>> GetNotUsedItemsWithMaterialAndUnitOfMeasurePaginated(PaginationModel model);
}