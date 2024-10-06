using Microsoft.EntityFrameworkCore;
using ProcApi.Domain.Entities;
using ProcApi.Domain.Models;
using ProcApi.Infrastructure.Data;
using ProcApi.Infrastructure.Repositories.Abstracts;
using ProcApi.Infrastructure.Utility;

namespace ProcApi.Infrastructure.Repositories.Concreates;

public class GoodReceiptNoteItemRepository : GenericRepository<GoodReceiptNoteItem, int>, IGoodReceiptNoteItemRepository
{
    public GoodReceiptNoteItemRepository(ProcDbContext context) : base(context)
    {
    }

    public async Task<Paginator<GoodReceiptNoteItem>> GetNotUsedItemsWithMaterialAndUnitOfMeasurePaginated(
        PaginationModel pagination)
    {
        var query = _context.GoodReceiptNoteItems
            .Include(grni => grni.GoodReceiptNote)
            .ThenInclude(grn => grn.Document)
            .Include(grni => grni.Material)
            .Include(grni => grni.UnitOfMeasure)
            .Where(grni => grni.Quantity != grni.UsedQuantity
            && (grni.GoodReceiptNote.Document.Number.Contains(pagination.Search)
            || grni.Material.Name.Contains(pagination.Search)));

        return await Paginator<GoodReceiptNoteItem>.FromQuery(query, pagination.PageNumber, pagination.PageSize);
    }
}