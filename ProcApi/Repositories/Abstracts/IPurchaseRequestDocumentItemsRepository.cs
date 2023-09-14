using ProcApi.Data.ProcDatabase.Models;

namespace ProcApi.Repositories.Abstracts;

public interface IPurchaseRequestDocumentItemsRepository : IGenericRepository<PurchaseRequestDocumentItem>
{
    Task<IEnumerable<PurchaseRequestDocumentItem>> GetAllByDocIdAsync(int docId);
}