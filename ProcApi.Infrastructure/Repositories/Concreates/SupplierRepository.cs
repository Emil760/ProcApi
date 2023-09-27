using Microsoft.EntityFrameworkCore;
using ProcApi.Domain.Entities;
using ProcApi.Domain.Models;
using ProcApi.Infrastructure.Data;
using ProcApi.Infrastructure.Repositories.Abstracts;
using ProcApi.Infrastructure.Utility;

namespace ProcApi.Infrastructure.Repositories.Concreates;

public class SupplierRepository : GenericRepository<Supplier>, ISupplierRepository
{
    public SupplierRepository(ProcDbContext context) : base(context)
    {
    }

    public async Task<Supplier?> GetSupplierByNameAndTaxIdAsync(string name, string taxId)
    {
        return await _context.Suppliers
            .SingleOrDefaultAsync(s => s.Name == name || s.TaxId == taxId);
    }

    public async Task<Paginator<Supplier>> GetAllPaginated(PaginationModel pagination)
    {
        var query = _context.Suppliers
            .Where(u => u.Name.Contains(pagination.Search) || u.TaxId.Contains(pagination.Search))
            .AsQueryable();

        return await Paginator<Supplier>.FromQuery(query, pagination.PageNumber, pagination.PageSize);
    }

    public async Task<Supplier?> GetSupplierExceptCurrentByNameAndTaxIdAsync(int id, string name, string taxId)
    {
        return await _context.Suppliers
            .SingleOrDefaultAsync(s => s.Id != id && (s.Name == name || s.TaxId == taxId));
    }
}