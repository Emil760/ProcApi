using Microsoft.EntityFrameworkCore;
using ProcApi.Domain.Entities;
using ProcApi.Infrastructure.Data;
using ProcApi.Infrastructure.Repositories.Abstracts;

namespace ProcApi.Infrastructure.Repositories.Concreates;

public class PurchaseRequestRepository : GenericRepository<PurchaseRequest>,
    IPurchaseRequestRepository
{
    public PurchaseRequestRepository(ProcDbContext context) : base(context)
    {
    }

    public async Task<PurchaseRequest?> GetWithDocumentAndItemsByDocId(int docId)
    {
        return await _context.PurchaseRequests
            .Include(prd => prd.Items)
            .Include(prd => prd.Document)
            .SingleOrDefaultAsync(prd => prd.DocumentId == docId);
    }

    public async Task<PurchaseRequest?> GetWithDocumentAndActionsAndItemsByDocId(int docId)
    {
        return await _context.PurchaseRequests
            .Include(prd => prd.Document)
            .Include(d => d.Document.Actions)
            .ThenInclude(d => d.Assigner)
            .Include(d => d.Document.Actions)
            .ThenInclude(d => d.Performer)
            .Include(prd => prd.Items)
            .ThenInclude(i => i.Buyer)
            .SingleOrDefaultAsync(prd => prd.DocumentId == docId);
    }
}