using Microsoft.EntityFrameworkCore;
using ProcApi.Data.ProcDatabase;

namespace ProcApi.Repositories.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ProcDbContext _context;

        public UnitOfWork(ProcDbContext context)
        {
            _context = context;
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Attach(object entity)
        {
            _context.Attach(entity);
        }

        public void MakeUnchanged(object entity)
        {
            _context.Entry(entity).State = EntityState.Unchanged;
        }

        public void MarkAdd(object entity)
        {
            _context.Entry(entity).State = EntityState.Added;
        }

        public void MarkBulkAdd(IEnumerable<object> entities)
        {
            foreach (var entity in entities)
            {
                MarkAdd(entity);
            }
        }
    }
}