using ProcApi.Domain.Enums;

namespace ProcApi.Application.Services.Abstracts
{
    public interface IDocumentNumberGenerator
    {
        Task<string> GenerateDocumentNumber(int docId, DocumentType documentType);
    }
}
