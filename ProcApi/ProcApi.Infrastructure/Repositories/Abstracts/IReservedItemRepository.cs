using ProcApi.Domain.Entities;
using ProcApi.Domain.Models;
using ProcApi.Infrastructure.Utility;

namespace ProcApi.Infrastructure.Repositories.Abstracts
{
    public interface IReservedItemRepository : IGenericRepository<ReservedItem, int>
    {
        Task<Paginator<ReservedItem>> GetWithGoodReceiptNoteAndMaterialPaginated(PaginationModel pagination);
    }
}
