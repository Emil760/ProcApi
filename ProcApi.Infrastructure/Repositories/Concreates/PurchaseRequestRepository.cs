using Microsoft.EntityFrameworkCore;
using ProcApi.Domain.Entities;
using ProcApi.Infrastructure.Data;
using ProcApi.Infrastructure.Repositories.Abstracts;

namespace ProcApi.Infrastructure.Repositories.Concreates
{
    public class PurchaseRequestRepository : GenericRepository<PurchaseRequest>,
        IPurchaseRequestRepository
    {
        public PurchaseRequestRepository(ProcDbContext context) : base(context)
        {
        }

        public async Task<PurchaseRequest?> GetWithDocumentAndItemsByDocId(int docId)
        {
            return await _context.PurchaseRequestDocuments
                .Include(prd => prd.Items)
                .Include(prd => prd.Document)
                .SingleOrDefaultAsync(prd => prd.DocumentId == docId);
        }

        public async Task<PurchaseRequest?> GetWithDocumentAndActionsAndItemsByDocId(int docId)
        {
            return await _context.PurchaseRequestDocuments
                .Include(prd => prd.Document)
                .ThenInclude(d => d.Actions)
                .ThenInclude(d => d.User)
                .Include(prd => prd.Items)
                .SingleOrDefaultAsync(prd => prd.DocumentId == docId);
        }
    }
}