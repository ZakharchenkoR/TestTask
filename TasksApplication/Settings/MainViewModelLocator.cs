
//class to dependency injection from Ninject
namespace TasksApplication.Settings
{
    using BLL.Modules;
    using Ninject;
    using ViewModel;
    public class MainViewModelLocator
    {
        private readonly IKernel _kernel;
        public MainViewModel ViewModel => this._kernel.Get<MainViewModel>();
        public MainViewModelLocator() => this._kernel = new StandardKernel(new TaskDIModule());
    }
}