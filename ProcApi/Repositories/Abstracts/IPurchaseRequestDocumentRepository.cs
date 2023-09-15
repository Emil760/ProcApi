using ProcApi.Data.ProcDatabase.Models;

namespace ProcApi.Repositories.Abstracts;

public interface IPurchaseRequestDocumentRepository : IGenericRepository<PurchaseRequestDocument>
{
    Task<PurchaseRequestDocument?> GetDocumentWithItems(int docId);
    Task<PurchaseRequestDocument?> GetDocumentWithActionsAndItems(int docId);
}