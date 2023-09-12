using Npgsql.Replication.PgOutput.Messages;

namespace ProcApi.Repositories.UnitOfWork
{
    public interface IUnitOfWork
    {
        Task SaveChangesAsync();
        void Attach(object entity);
        void MakeUnchanged(object entity);
        void MarkAdd(object entity);
        void MarkBulkAdd(IEnumerable<object> entities);
    }
}