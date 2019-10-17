
namespace TasksApplication.Model
{
    using System.Collections.Generic;
    public interface ITaskModelRepository<T>
    {
        IEnumerable<T> GetAll();
        void Add(T item);
    }
}