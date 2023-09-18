using Microsoft.EntityFrameworkCore;
using ProcApi.Data.ProcDatabase;
using ProcApi.Data.ProcDatabase.Models;
using ProcApi.DTOs.Base;
using ProcApi.Repositories.Abstracts;
using ProcApi.Utility;

namespace ProcApi.Repositories.Concreates;

public class MaterialRepository : GenericRepository<Material>, IMaterialRepository
{
    public MaterialRepository(ProcDbContext context) : base(context)
    {
    }

    public async Task<Paginator<Material>> GetAllPaginated(PaginationRequestDto dto)
    {
        var query = _context.Materials
            .Include(m => m.Category)
            .Where(u => u.Name.Contains(dto.Search) || u.Description.Contains(dto.Search))
            .AsQueryable();

        return await Paginator<Material>.FromQuery(query, dto.PageNumber, dto.PageSize);
    }

    public async Task<bool> ExistsByCode(string code)
    {
        return await _context.Materials.AnyAsync(m => m.Code == code);
    }

    public async Task<bool> ExistsByCodeAndName(string name, string code)
    {
        return await _context.Materials.AnyAsync(m => m.Name == name
                                                      || m.Code == code);
    }

    public async Task<Material?> FindByCodeAndNameExceptCurrent(int id, string name, string code)
    {
        return await _context.Materials.SingleOrDefaultAsync(m => m.Id != id
                                                                  && (m.Name == name || m.Code == code));
    }

    public async Task<Material?> FindByCodeOrName(string name, string code)
    {
        return await _context.Materials.SingleOrDefaultAsync(m => m.Name == name
                                                                  || m.Code == code);
    }
}