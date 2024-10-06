using Microsoft.EntityFrameworkCore;
using ProcApi.Domain.Entities;
using ProcApi.Domain.Enums;
using ProcApi.Domain.Models;
using ProcApi.Domain.ResultSets;
using ProcApi.Infrastructure.Data;
using ProcApi.Infrastructure.Repositories.Abstracts;
using ProcApi.Infrastructure.Utility;

namespace ProcApi.Infrastructure.Repositories.Concreates;

public class UserRepository : GenericRepository<User, int>, IUserRepository
{
    private static readonly Func<ProcDbContext, int, Task<User>> GetById =
        EF.CompileAsyncQuery((ProcDbContext context, int id) =>
            context.Set<User>().FirstOrDefault(u => u.Id == id));

    public UserRepository(ProcDbContext context) : base(context)
    {
    }

    public async Task<User> GetByIdCompiled(int id)
    {
        return await GetById(_context, id);
    }

    public async Task<User?> GetAllInfoByIdAsync(int id)
    {
        return await _context.Users
            .Include(u => u.Department)
            .Include(u => u.Dashboard)
            .SingleOrDefaultAsync(u => u.Id == id);
    }

    public async Task<IEnumerable<User>> GetAllWithRoles(string search)
    {
        return await _context.Users
            .Include(u => u.Roles)
            .Where(u => u.Login.Contains(search) || u.Roles.Any(r => r.Name.Contains(search)))
            .ToListAsync();
    }

    public async Task<IEnumerable<User>> GetAllByRoleAsync(int roleId)
    {
        return await _context.Users
            .Where(u => u.Roles.Any(r => r.Id == roleId))
            .ToListAsync();
    }

    public async Task<IEnumerable<User>> GetAllByRoleNameAsync(string name)
    {
        return await _context.Users
            .Where(u => u.Roles.Any(r => EF.Functions.ILike(r.Name, $"%{name}%")))
            .ToListAsync();
    }

    public async Task<IEnumerable<User>> GetByIdsAsync(params int[] ids)
    {
        return await _context.Users
            .Where(u => ids.Contains(u.Id))
            .ToListAsync();
    }

    public async Task<User?> GetWithRolesById(int id)
    {
        return await _context.Users
            .Include(u => u.Roles)
            .SingleOrDefaultAsync(u => u.Id == id);
    }

    public async Task<bool> ExistsByLogin(string login)
    {
        return await _context.Users
            .Where(u => u.Login == login)
            .AnyAsync();
    }

    public async Task<User?> GetWithPasswordHashByLogin(string login)
    {
        return await _context.Users
            .Include(u => u.UserPassword)
            .FirstOrDefaultAsync(u => u.Login == login);
    }

    public async Task<IEnumerable<string>> GetPermissions(int id)
    {
        return await _context.Users
            .Where(u => u.Id == id)
            .SelectMany(u => u.Roles)
            .SelectMany(r => r.Permissions)
            .Select(p => p.Name)
            .Distinct()
            .ToListAsync();
    }

    public async Task<IEnumerable<string>> GetPermissionsUnionDelegatedPermissions(int id)
    {
        var p1 = _context.Users
            .Where(u => u.Id == id)
            .SelectMany(u => u.Roles)
            .SelectMany(r => r.Permissions)
            .Select(p => p.Name);

        var p2 = _context.Delegations
            .Where(d => d.ToUserId == id && d.EndDate >= DateTime.Now.Date)
            .Select(d => d.FromUser)
            .SelectMany(u => u.Roles)
            .SelectMany(r => r.Permissions)
            .Select(p => p.Name);

        return await p1.Union(p2).Distinct().ToListAsync();
    }

    public async Task<IEnumerable<int>> GetRoles(int id)
    {
        return await _context.Users
            .Where(u => u.Id == id)
            .SelectMany(u => u.Roles.Select(r => r.Id))
            .ToListAsync();
    }

    public async Task<IEnumerable<int>> GetRolesUnionDelegatedRoles(int id)
    {
        var u1 = _context.Users
            .Where(u => u.Id == id)
            .SelectMany(u => u.Roles.Select(r => r.Id));

        var u2 = _context.Delegations
            .Where(d => d.ToUserId == id && d.EndDate >= DateTime.Now.Date)
            .SelectMany(d => d.FromUser.Roles.Select(r => r.Id));

        return await u1.Union(u2).ToListAsync();
    }

    public async Task<bool> HasRoleAsync(int id, Roles role)
    {
        var u1 = _context.Users
            .Where(u => u.Id == id)
            .SelectMany(u => u.Roles.Select(r => r.Id));

        var u2 = _context.Delegations
            .Where(d => d.ToUserId == id && d.EndDate >= DateTime.Now.Date)
            .SelectMany(d => d.FromUser.Roles.Select(r => r.Id));

        return await u1.Union(u2).AnyAsync(u => u == (int)role);
    }

    public async Task<Paginator<User>> GetAllPaginated(PaginationModel pagination)
    {
        var query = _context.Users
            .Where(u => u.FirstName.Contains(pagination.Search))
            .AsQueryable();

        return await Paginator<User>.FromQuery(query, pagination.PageNumber, pagination.PageSize);
    }

    public async Task<IEnumerable<User>> GetAllInfosAsync()
    {
        return await _context.Users
            .Include(u => u.Dashboard)
            .Include(u => u.Department)
            .ToListAsync();
    }

    public async Task<User?> GetByIdAndRoleId(int userId, Roles role)
    {
        return await _context.Users
            .Where(u => u.Id == userId
                        && u.Roles.Any(r => r.Id == (int)role))
            .SingleOrDefaultAsync();
    }

    public async Task<IEnumerable<User>> GetAllAsync(IEnumerable<int> userIds)
    {
        return await _context.Users
            .Where(u => userIds.Contains(u.Id))
            .ToListAsync();
    }

    public async Task<IEnumerable<UserRoleResultSet>> GetUserRolesWithDelegatedRoles(int id, int delegatedUserId)
    {
        return await _context.GetUserRolesWithDelegatedRoles(id, delegatedUserId)
            .ToListAsync();
    }
}