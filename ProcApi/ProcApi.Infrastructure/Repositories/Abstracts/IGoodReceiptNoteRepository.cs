using ProcApi.Domain.Entities;

namespace ProcApi.Infrastructure.Repositories.Abstracts;

public interface IGoodReceiptNoteRepository : IGenericRepository<GoodReceiptNote, int>
{
    Task<GoodReceiptNote?> GetWithDocumentAndActionsAndItemsByDocId(int docId);
    Task<GoodReceiptNote?> GetWithDocumentAndItemsByDocId(int docId);
}