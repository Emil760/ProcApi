using ProcApi.Data.ProcDatabase.Enums;
using ProcApi.Data.ProcDatabase.Models;
using ProcApi.Services.Abstracts;

namespace ProcApi.Services.Concreates;

public class DocumentService : IDocumentService
{
    public Document CreateDocument(int userId, DocumentType type, DocumentStatus status)
    {
        return new Document()
        {
            CreatedById = userId,
            DocumentTypeId = type,
            DocumentStatusId = status,
            CreatedOn = DateTime.Now
        };
    }
}