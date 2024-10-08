﻿using Microsoft.EntityFrameworkCore;
using ProcApi.Domain.Entities;
using ProcApi.Domain.Models;
using ProcApi.Domain.ResultSets;
using ProcApi.Infrastructure.Data;
using ProcApi.Infrastructure.Repositories.Abstracts;

namespace ProcApi.Infrastructure.Repositories.Concreates;

public class InvoiceRepository : GenericRepository<Invoice, int>, IInvoiceRepository
{
    public InvoiceRepository(ProcDbContext context) : base(context)
    {
    }

    public async Task<Invoice?> GetWithDocumentAndActionsAndItemsByDocId(int docId)
    {
        return await _context.Invoices
            .Include(id => id.Document)
            .Include(d => d.Document.Actions)
            .ThenInclude(d => d.Assigner)
            .Include(d => d.Document.Actions)
            .ThenInclude(d => d.Performer)
            .Include(id => id.Items)
            .SingleOrDefaultAsync(id => id.Id == docId);
    }

    public async Task<Invoice?> GetWithDocumentAndItemsByDocId(int docId)
    {
        return await _context.Invoices
            .Include(i => i.Items)
            .Include(i => i.Document)
            .SingleOrDefaultAsync(i => i.Id == docId);
    }

    public async Task<IEnumerable<UnusedPRItemInfoResultSet>> GetUnusedPurchaseRequestItemsAsync(
        PaginationModel model)
    {
        return await _context.GetUnusedPurchaseRequestItemsInfo(
                model.PageNumber,
                model.PageSize,
                "%" + model.Search + "%")
            .ToListAsync();
    }

    public async Task<IEnumerable<UnusedPRItemResultSet>> GetUnusedPurchaseRequestItemsByIdsAsync(int[] ids)
    {
        return await _context.GetUnusedPurchaseRequestItemsByIds(ids)
            .ToListAsync();
    }
}