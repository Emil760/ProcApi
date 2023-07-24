using System.Linq.Expressions;

namespace ProcApi.Extensions
{
    public static class IQueryExtensions
    {
        public static IQueryable<T> WhereIf<T>(this IQueryable<T> queryable, bool condition, Expression<Func<T, bool>> predicate)
        {
            return condition ? queryable.Where(predicate) : queryable;
        }
    }
}
