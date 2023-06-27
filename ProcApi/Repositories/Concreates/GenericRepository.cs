using Microsoft.EntityFrameworkCore;
using ProcApi.Data.ProcDatabase;
using ProcApi.Repositories.Abstracts;
using System.Linq.Expressions;

namespace ProcApi.Repositories.Concreates
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private ProcDbContext _context;

        public GenericRepository(ProcDbContext context)
        {
            _context = context;
        }

        public virtual async Task<T> GetByIdAsync(object id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public virtual async Task<IEnumerable<T>> GetAllByConditionAsync(Expression<Func<T, bool>> expression)
        {
            if (expression != null)
                return await _context.Set<T>().Where(expression).ToListAsync();
            return await _context.Set<T>().ToListAsync();
        }

        public async Task InsertAsync(T entity)
        {
            _context.Add(entity);

            await _context.SaveChangesAsync();
        }

        public void Insert(T entity)
        {
            _context.Add(entity);
        }
    }
}
