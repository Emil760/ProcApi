using ProcApi.Domain.Entities;
using ProcApi.Domain.Models;
using ProcApi.Infrastructure.Utility;

namespace ProcApi.Infrastructure.Repositories.Abstracts;

public interface ISupplierRepository : IGenericRepository<Supplier, int>
{
    Task<Supplier?> GetSupplierByNameAndTaxIdAsync(string name, string taxId);
    Task<Paginator<Supplier>> GetAllPaginated(PaginationModel pagination);
    Task<Supplier?> GetSupplierExceptCurrentByNameAndTaxIdAsync(int id, string name, string taxId);
}