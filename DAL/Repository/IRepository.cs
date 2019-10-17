
//interface to dependency injection
namespace DAL.Repository
{
    using System.Collections.Generic;
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();
        void Add(T item);
        void Delete(T item);
        void Update(T item);
        T Get(int id);
        void Save();
    }
}