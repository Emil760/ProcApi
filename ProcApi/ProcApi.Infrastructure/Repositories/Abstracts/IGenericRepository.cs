using ProcApi.Domain.Interfaces;
using System.Linq.Expressions;

namespace ProcApi.Infrastructure.Repositories.Abstracts;

public interface IGenericRepository<T1, T2> where T1 : IEntity<T2>
{
    Task<T1?> GetByIdAsync(T2 id);
    Task<IEnumerable<T1>> GetAllAsync();
    Task<IEnumerable<T1>> GetAllByConditionAsync(Expression<Func<T1, bool>>? expression);
    Task InsertAsync(T1 entity);
    Task InsertAsync(IEnumerable<T1> entities);
    void Insert(T1 entity);
    void Insert(IEnumerable<T1> entities);
    void DeleteById(T1 entity);
    Task DeleteByIdAsync(T1 entity);
    Task<bool> ExistsById(T2 id);
}