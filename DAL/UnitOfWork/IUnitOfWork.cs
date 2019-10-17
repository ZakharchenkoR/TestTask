
//interface to dependency injection
namespace DAL.UnitOfWork
{
    using Context;
    using Repository;
    public interface IUnitOfWork
    {
        IRepository<Task> Task { get; }
        void Save();
    }
}