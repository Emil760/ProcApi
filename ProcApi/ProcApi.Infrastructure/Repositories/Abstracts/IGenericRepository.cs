using System.Linq.Expressions;

namespace ProcApi.Infrastructure.Repositories.Abstracts;

public interface IGenericRepository<T> where T : class
{
    Task<T?> GetByIdAsync(object id);
    Task<IEnumerable<T>> GetAllAsync();
    Task<IEnumerable<T>> GetAllByConditionAsync(Expression<Func<T, bool>>? expression);
    Task InsertAsync(T entity);
    Task InsertAsync(IEnumerable<T> entities);
    void Insert(T entity);
    void Insert(IEnumerable<T> entities);
    void DeleteById(T entity);
    Task DeleteByIdAsync(T entity);
}