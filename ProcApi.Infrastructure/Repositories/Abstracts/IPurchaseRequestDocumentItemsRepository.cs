using ProcApi.Domain.Entities;

namespace ProcApi.Infrastructure.Repositories.Abstracts;

public interface IPurchaseRequestDocumentItemsRepository : IGenericRepository<PurchaseRequestDocumentItem>
{
    Task<IEnumerable<PurchaseRequestDocumentItem>> GetAllByDocIdAsync(int docId);
}