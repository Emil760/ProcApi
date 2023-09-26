using Microsoft.EntityFrameworkCore;
using ProcApi.Domain.Entities;
using ProcApi.Infrastructure.Data;
using ProcApi.Infrastructure.Repositories.Abstracts;

namespace ProcApi.Infrastructure.Repositories.Concreates
{
    public class PurchaseRequestDocumentRepository : GenericRepository<PurchaseRequestDocument>,
        IPurchaseRequestDocumentRepository
    {
        public PurchaseRequestDocumentRepository(ProcDbContext context) : base(context)
        {
        }

        public async Task<PurchaseRequestDocument?> GetDocumentWithItems(int docId)
        {
            return await _context.PurchaseRequestDocuments
                .Include(prd => prd.Items)
                .SingleOrDefaultAsync(prd => prd.DocumentId == docId);
        }

        public async Task<PurchaseRequestDocument?> GetDocumentWithActionsAndItems(int docId)
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