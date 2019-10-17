// class service how done CRUD operation with DB from DAL project
namespace BLL.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using Model;
    using DAL.Context;
    using DAL.UnitOfWork;
    public class TaskService : IService<TaskDto>
    {
        private readonly IUnitOfWork _unitOfWork;

        public TaskService(IUnitOfWork unitOfWork) => this._unitOfWork = unitOfWork;

        public IEnumerable<TaskDto> GetAll() => this._unitOfWork.Task.GetAll().Select(x => new TaskDto()
        {
            Id = x.Id,
            Title = x.Title,
            StartData = x.StartData,
            EndData = x.EndData,
            Condition = x.Condition
        });

        public void Remove(TaskDto item)
        {
            this._unitOfWork.Task.Delete(this._unitOfWork.Task.Get(item.Id));
            this._unitOfWork.Save();
        }

        public void Add(TaskDto item)
        {
            this._unitOfWork.Task.Add(new Task()
            {
                Title = item.Title,
                StartData = item.StartData,
                EndData = item.EndData,
                Condition = item.Condition
            });
            this._unitOfWork.Save();
        }

        public void Update(TaskDto item)
        {
            this._unitOfWork.Task.Update(new Task()
            {
                Id = item.Id,
                Title = item.Title,
                StartData = item.StartData,
                EndData = item.EndData,
                Condition = item.Condition
            });
            this._unitOfWork.Save();
        }
    }
}