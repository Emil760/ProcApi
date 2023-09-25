﻿using Microsoft.EntityFrameworkCore;
using ProcApi.Data.ProcDatabase;
using ProcApi.Data.ProcDatabase.Enums;
using ProcApi.Data.ProcDatabase.Models;
using ProcApi.Repositories.Abstracts;

namespace ProcApi.Repositories.Concreates;

public class DocumentRepository : GenericRepository<Document>, IDocumentRepository
{
    public DocumentRepository(ProcDbContext context) : base(context)
    {
    }

    public async Task<Document?> GetWithActions(int docId)
    {
        return await _context.Documents
            .Include(d => d.Actions)
            .SingleOrDefaultAsync(d => d.Id == docId);
    }

    public async Task<DocumentStatus> GetStatus(int docId)
    {
        return await _context.Documents
            .Where(doc => doc.Id == docId)
            .Select(doc => doc.StatusId)
            .SingleOrDefaultAsync();
    }
}