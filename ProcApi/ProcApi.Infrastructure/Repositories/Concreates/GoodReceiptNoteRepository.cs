using Microsoft.EntityFrameworkCore;
using ProcApi.Domain.Entities;
using ProcApi.Infrastructure.Data;
using ProcApi.Infrastructure.Repositories.Abstracts;

namespace ProcApi.Infrastructure.Repositories.Concreates;

public class GoodReceiptNoteRepository : GenericRepository<GoodReceiptNote>, IGoodReceiptNoteRepository
{
    public GoodReceiptNoteRepository(ProcDbContext context) : base(context)
    {
    }

    public async Task<GoodReceiptNote?> GetWithDocumentAndActionsAndItemsByDocId(int docId)
    {
        return await _context.GoodReceiptNotes
            .Include(grn => grn.Document)
            .Include(d => d.Document.Actions)
            .ThenInclude(d => d.Assigner)
            .Include(d => d.Document.Actions)
            .ThenInclude(d => d.Performer)
            .Include(grn => grn.Items)
            .SingleOrDefaultAsync(grn => grn.DocumentId == docId);
    }

    public async Task<GoodReceiptNote?> GetWithDocumentAndItemsByDocId(int docId)
    {
        return await _context.GoodReceiptNotes
            .Include(grn => grn.Items)
            .Include(grn => grn.Document)
            .SingleOrDefaultAsync(prd => prd.DocumentId == docId);
    }
}