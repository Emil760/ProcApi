using Microsoft.EntityFrameworkCore;
using ProcApi.Data.ProcDatabase;
using ProcApi.Data.ProcDatabase.Models;
using ProcApi.Repositories.Abstracts;

namespace ProcApi.Repositories.Concreates;

public class PurchaseRequestDocumentItemsRepository : GenericRepository<PurchaseRequestDocumentItem>,
    IPurchaseRequestDocumentItemsRepository
{
    public PurchaseRequestDocumentItemsRepository(ProcDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<PurchaseRequestDocumentItem>> GetAllByDocIdAsync(int docId)
    {
        return await _context.PurchaseRequestDocumentItems
            .Where(prdi => prdi.PurchaseRequestDocumentId == docId)
            .ToListAsync();
    }
}