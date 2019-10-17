// interface to dependency injection
namespace BLL.Services
{
    using System.Collections.Generic;
    public interface IService<T>
    {
        IEnumerable<T> GetAll();
        void Remove(T item);
        void Add(T item);
        void Update(T item);
    }
}