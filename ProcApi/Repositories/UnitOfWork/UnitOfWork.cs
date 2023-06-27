using ProcApi.Data.ProcDatabase;

namespace ProcApi.Repositories.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private ProcDbContext _context;

        public UnitOfWork(ProcDbContext context)
        {
            _context = context;
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
