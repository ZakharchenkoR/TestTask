
//class how done CRUD operations with DB
namespace DAL.Repository
{
    using System.Collections.Generic;
    using Context;
    using System.Data.Entity;
    using System.Linq;

    public class TaskRepository : IRepository<Task>
    {
        private readonly TasksDBEntities _db;

        public TaskRepository(TasksDBEntities tasksDbEntities) => this._db = tasksDbEntities;

        public IEnumerable<Task> GetAll() => this._db.Tasks;

        public void Add(Task item) => this._db.Tasks.Add(item);

        public void Delete(Task item) => this._db.Tasks.Remove(item);


        public void Update(Task item)
        {
            foreach (var task in this._db.Tasks)
            {
                if (task.Id == item.Id)
                {
                    task.Title = item.Title;
                    task.Condition = item.Condition;
                    task.EndData = item.EndData;
                    task.StartData = item.StartData;
                    this._db.Entry(task).State = EntityState.Modified;
                    break;
                }
            }
        }

        public Task Get(int id) => this._db.Tasks.FirstOrDefault(x => x.Id == id);

        public void Save() => this._db.SaveChanges();

        ~TaskRepository() => this._db.Dispose();
    }
}