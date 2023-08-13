using Microsoft.EntityFrameworkCore;
using ProcApi.Data.ProcDatabase;
using ProcApi.Data.ProcDatabase.Models;
using ProcApi.Repositories.Abstracts;

namespace ProcApi.Repositories.Concreates
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private ProcDbContext context;

        private static readonly Func<ProcDbContext, int, Task<User>> GetById =
            EF.CompileAsyncQuery((ProcDbContext context, int id) =>
                context.Set<User>().FirstOrDefault(u => u.Id == id));

        public UserRepository(ProcDbContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<User> GetByIdCompiled(int id)
        {
            return await GetById(context, id);
        }

        public async Task<string?> ExistsByLogin(string login)
        {
            return await context.Users.Where(u => u.Login == login)
                .Select(u => u.Login)
                .FirstOrDefaultAsync();
        }

        public async Task<User?> FindWithPasswordHashByLogin(string login)
        {
            return await context.Users
                .Include(u => u.UserPassword)
                .FirstOrDefaultAsync(u => u.Login == login);
        }

        public async Task<IEnumerable<string>> GetPermissions(int id)
        {
            return await context.Users
                .Where(u => u.Id == id)
                .SelectMany(u => u.Roles)
                .SelectMany(r => r.Permissions)
                .Select(p => p.Name)
                .Distinct()
                .ToListAsync();
        }
    }
}