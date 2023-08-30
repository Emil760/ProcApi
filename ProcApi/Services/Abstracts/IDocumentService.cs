using ProcApi.Data.ProcDatabase.Enums;
using ProcApi.Data.ProcDatabase.Models;
using ProcApi.DTOs.Documents;

namespace ProcApi.Services.Abstracts;

public interface IDocumentService
{
    Document CreateDocument(int userId, DocumentType type, DocumentStatus status);
}