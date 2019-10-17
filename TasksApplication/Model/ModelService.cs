//class to have only one reference to the BLL in the project responsible for UI. This class work with data from BLL
namespace TasksApplication.Model
{
    using System.Collections.Generic;
    using System.Linq;
    using BLL.Model;
    using BLL.Services;
    using System;
    public class ModelService : ITaskModelRepository<TaskModel>
    {
        private readonly IService<TaskDto> _service;
        public ModelService(IService<TaskDto> service) => this._service = service;

        //return data from BLL and map this data on TaskModel
        public IEnumerable<TaskModel> GetAll() => this._service.GetAll().Select(x => new TaskModel()
        {
            Id = x.Id,
            Title = x.Title,
            StartData = x.StartData,
            EndData = x.EndData,
            Condition = (Condition)Enum.ToObject(typeof(Condition),x.Condition)
        });

        //save new Task to DB
        public void Add(TaskModel item)
        {
            this._service.Add(new TaskDto()
            {
                Id = item.Id,
                Title = item.Title,
                StartData = item.StartData,
                EndData = item.EndData,
                Condition = (int)item.Condition
            });
        }
    }
}