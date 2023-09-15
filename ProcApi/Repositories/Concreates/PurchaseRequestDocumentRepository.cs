﻿using Microsoft.EntityFrameworkCore;
using ProcApi.Data.ProcDatabase;
using ProcApi.Data.ProcDatabase.Models;
using ProcApi.Repositories.Abstracts;

namespace ProcApi.Repositories.Concreates;

public class PurchaseRequestDocumentRepository : GenericRepository<PurchaseRequestDocument>,
    IPurchaseRequestDocumentRepository
{
    public PurchaseRequestDocumentRepository(ProcDbContext context) : base(context)
    {
    }

    public async Task<PurchaseRequestDocument?> GetDocumentWithItems(int docId)
    {
        return await _context.PurchaseRequestDocuments
            .Include(prd => prd.Document)
            .Include(prd => prd.Items)
            .SingleOrDefaultAsync(prd => prd.DocumentId == docId);
    }

    public async Task<PurchaseRequestDocument?> GetDocumentWithActionsAndItems(int docId)
    {
        return await _context.PurchaseRequestDocuments
            .Include(prd => prd.Document)
            .ThenInclude(d => d.DocumentActions)
            .ThenInclude(d => d.User)
            .Include(prd => prd.Items)
            .SingleOrDefaultAsync(prd => prd.DocumentId == docId);
    }
}