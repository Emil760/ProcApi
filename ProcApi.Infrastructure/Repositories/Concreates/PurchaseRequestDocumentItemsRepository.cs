using Microsoft.EntityFrameworkCore;
using ProcApi.Domain.Entities;
using ProcApi.Infrastructure.Data;
using ProcApi.Infrastructure.Repositories.Abstracts;

namespace ProcApi.Infrastructure.Repositories.Concreates
{
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
}