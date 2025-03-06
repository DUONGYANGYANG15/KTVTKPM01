using ASC.Model.BaseTypes;

namespace ASC.DataAccess.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<T> Repository<T>() where T : BaseEntity;

        public int CommitTransaction();
    }
}
