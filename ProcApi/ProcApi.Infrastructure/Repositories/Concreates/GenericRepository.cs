using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using ProcApi.Infrastructure.Data;
using ProcApi.Infrastructure.Repositories.Abstracts;

namespace ProcApi.Infrastructure.Repositories.Concreates;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    protected readonly ProcDbContext _context;

    public GenericRepository(ProcDbContext context)
    {
        _context = context;
    }

    public virtual async Task<T?> GetByIdAsync(object id)
    {
        return await _context.Set<T>().FindAsync(id);
    }

    public virtual async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _context.Set<T>().ToListAsync();
    }

    public virtual async Task<IEnumerable<T>> GetAllByConditionAsync(Expression<Func<T, bool>>? expression)
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

    public async Task InsertAsync(IEnumerable<T> entities)
    {
        foreach (var entity in entities)
            _context.Add(entity);

        await _context.SaveChangesAsync();
    }

    public void Insert(T entity)
    {
        _context.Add(entity);
    }

    public void Insert(IEnumerable<T> entities)
    {
        foreach (var entity in entities)
            _context.Add(entity);
    }

    public void DeleteById(T entity)
    {
        _context.Entry(entity).State = EntityState.Deleted;
    }

    public async Task DeleteByIdAsync(T entity)
    {
        _context.Entry(entity).State = EntityState.Deleted;
        await _context.SaveChangesAsync();
    }
}