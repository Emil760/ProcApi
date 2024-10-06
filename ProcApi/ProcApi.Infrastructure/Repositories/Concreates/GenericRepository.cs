using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using ProcApi.Domain.Interfaces;
using ProcApi.Infrastructure.Data;
using ProcApi.Infrastructure.Repositories.Abstracts;

namespace ProcApi.Infrastructure.Repositories.Concreates;

public class GenericRepository<T1, T2> : IGenericRepository<T1, T2> where T1 : class, IEntity<T2>
{
    protected readonly ProcDbContext _context;

    public GenericRepository(ProcDbContext context)
    {
        _context = context;
    }

    public virtual async Task<T1?> GetByIdAsync(T2 id)
    { 
        return await _context.Set<T1>().FindAsync(id);
    }

    public virtual async Task<IEnumerable<T1>> GetAllAsync()
    {
        return await _context.Set<T1>().ToListAsync();
    }

    public virtual async Task<IEnumerable<T1>> GetAllByConditionAsync(Expression<Func<T1, bool>>? expression)
    {
        if (expression != null)
            return await _context.Set<T1>().Where(expression).ToListAsync();
        return await _context.Set<T1>().ToListAsync();
    }

    public async Task InsertAsync(T1 entity)
    {
        _context.Add(entity);

        await _context.SaveChangesAsync();
    }

    public async Task InsertAsync(IEnumerable<T1> entities)
    {
        foreach (var entity in entities)
            _context.Add(entity);

        await _context.SaveChangesAsync();
    }

    public void Insert(T1 entity)
    {
        _context.Add(entity);
    }

    public void Insert(IEnumerable<T1> entities)
    {
        foreach (var entity in entities)
            _context.Add(entity);
    }

    public void DeleteById(T1 entity)
    {
        _context.Entry(entity).State = EntityState.Deleted;
    }

    public async Task DeleteByIdAsync(T1 entity)
    {
        _context.Entry(entity).State = EntityState.Deleted;
        await _context.SaveChangesAsync();
    }

    public async Task<bool> ExistsById(T2 id)
    {
        return await _context.Set<T1>().AnyAsync(x => x.Id!.Equals(id));
    }
}