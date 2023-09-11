using Microsoft.EntityFrameworkCore;
using ProcApi.Data.ProcDatabase;
using ProcApi.Data.ProcDatabase.Models;
using ProcApi.DTOs.Base;
using ProcApi.Repositories.Abstracts;
using ProcApi.Utility;

namespace ProcApi.Repositories.Concreates
{
    public class UserRepository : GenericRepository<User>, IUserRepository
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

        public async Task<string?> ExistsByLogin(string login)
        {
            return await _context.Users.Where(u => u.Login == login)
                .Select(u => u.Login)
                .FirstOrDefaultAsync();
        }

        public async Task<User?> FindWithPasswordHashByLogin(string login)
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

        public async Task<User?> GetWithRoles(int id)
        {
            return await _context.Users
                .Include(u => u.Roles)
                .Where(u => u.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task<Paginator<User>> GetAllPaginated(PaginationRequestDto dto)
        {
            var query = _context.Users
                .Where(u => u.FirstName.Contains(dto.Search))
                .AsQueryable();

            return await Paginator<User>.FromQuery(query, dto.PageNumber, dto.PageSize);
        }
    }
}