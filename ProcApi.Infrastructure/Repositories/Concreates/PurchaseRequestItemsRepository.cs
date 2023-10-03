using Microsoft.EntityFrameworkCore;
using ProcApi.Domain.Entities;
using ProcApi.Infrastructure.Data;
using ProcApi.Infrastructure.Repositories.Abstracts;

namespace ProcApi.Infrastructure.Repositories.Concreates;

public class PurchaseRequestItemsRepository : GenericRepository<PurchaseRequestItem>,
    IPurchaseRequestItemsRepository
{
    public PurchaseRequestItemsRepository(ProcDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<PurchaseRequestItem>> GetAllByDocIdAsync(int docId)
    {
        return await _context.PurchaseRequestDocumentItems
            .Where(prdi => prdi.PurchaseRequestId == docId)
            .ToListAsync();
    }
}