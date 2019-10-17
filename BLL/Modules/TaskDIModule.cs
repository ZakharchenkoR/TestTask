
//class for dependency injection from Ninject
namespace BLL.Modules
{
    using Model;
    using Services;
    using DAL.Context;
    using DAL.Repository;
    using Ninject.Modules;
    using DAL.UnitOfWork;
    public class TaskDIModule :NinjectModule
    {
        public override void Load()
        {
            Bind<IRepository<Task>>().To<TaskRepository>();
            Bind<IService<TaskDto>>().To<TaskService>();
            Bind<IUnitOfWork>().To<UnitOfWork>();
        }
    }
}