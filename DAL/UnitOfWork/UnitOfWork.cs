
// class for work with one context
namespace DAL.UnitOfWork
{
    using Context;
    using Repository;
    public class UnitOfWork :IUnitOfWork
    {
        private readonly TasksDBEntities _db;

        private IRepository<Task> _task;
        public UnitOfWork() => this._db = new TasksDBEntities();
        public IRepository<Task> Task => _task = _task ?? new TaskRepository(this._db);
        public void Save() => this._db.SaveChanges();
    }
}