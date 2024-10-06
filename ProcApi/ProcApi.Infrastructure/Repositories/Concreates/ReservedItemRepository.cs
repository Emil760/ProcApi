using Microsoft.EntityFrameworkCore;
using ProcApi.Domain.Entities;
using ProcApi.Domain.Models;
using ProcApi.Infrastructure.Data;
using ProcApi.Infrastructure.Repositories.Abstracts;
using ProcApi.Infrastructure.Utility;

namespace ProcApi.Infrastructure.Repositories.Concreates
{
    public class ReservedItemRepository : GenericRepository<ReservedItem, int>, IReservedItemRepository
    {
        public ReservedItemRepository(ProcDbContext context) : base(context)
        {
        }

        public async Task<Paginator<ReservedItem>> GetWithGoodReceiptNoteAndMaterialPaginated(PaginationModel pagination)
        {
            var query = _context.ReservedItems
               .Include(rt => rt.GoodReceiptNoteItem)
               .ThenInclude(rt => rt.Material)
               .Include(rt => rt.GoodReceiptNoteItem)
               .ThenInclude(rt => rt.UnitOfMeasure)
               .Include(rt => rt.GoodReceiptNoteItem)
               .ThenInclude(rt => rt.GoodReceiptNote)
               .ThenInclude(rt => rt.Document)
               .Where(rt => rt.GoodReceiptNoteItem.GoodReceiptNote.Document.Number.Contains(pagination.Search)
                      || rt.GoodReceiptNoteItem.Material.Name.Contains(pagination.Search))
               .AsQueryable();

            return await Paginator<ReservedItem>.FromQuery(query, pagination.PageNumber, pagination.PageSize);
        }
    }
}
