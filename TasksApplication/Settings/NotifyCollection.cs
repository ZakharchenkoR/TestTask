//custom collection how  shows changes in the collection and adds data to the database at the same time
namespace TasksApplication.Settings
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using Model;
    public class NotifyCollection<T> : ObservableCollection<T>  where T : class
    {
        private readonly ITaskModelRepository<T> _service;
        public NotifyCollection(ITaskModelRepository<T> service)
        {
            this._service = service;
            foreach (var item in service.GetAll())
            {
                this.Add(item);
            }
        }
        public NotifyCollection(IEnumerable<T> dataSource)
        {
            foreach (var item in dataSource)
            {
                this.Add(item);
            }
        }
        public void AddNewItem(T item)
        {
            base.Add(item);
            _service.Add(item);
        }
    }
}
