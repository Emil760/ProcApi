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
}