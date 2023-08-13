using System.Linq.Expressions;

namespace ProcApi.Repositories.Abstracts
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetByIdAsync(object id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> GetAllByConditionAsync(Expression<Func<T, bool>>? expression);
        Task InsertAsync(T entity);
        void Insert(T entity);
    }
}
