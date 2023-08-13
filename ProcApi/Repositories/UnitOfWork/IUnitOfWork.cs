namespace ProcApi.Repositories.UnitOfWork
{
    public interface IUnitOfWork
    {
        Task SaveChangesAsync();
        void Attach(object entity);
        void MakeUnchanged(object entity);
    }
}