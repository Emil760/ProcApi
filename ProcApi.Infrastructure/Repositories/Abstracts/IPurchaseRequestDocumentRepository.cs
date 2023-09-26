using ProcApi.Domain.Entities;

namespace ProcApi.Infrastructure.Repositories.Abstracts;

public interface IPurchaseRequestDocumentRepository : IGenericRepository<PurchaseRequestDocument>
{
    Task<PurchaseRequestDocument?> GetDocumentWithItems(int docId);
    Task<PurchaseRequestDocument?> GetDocumentWithActionsAndItems(int docId);
}