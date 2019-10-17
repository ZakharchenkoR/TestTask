
namespace TasksApplication.Settings
{
    using System;
    using System.Windows.Input;
    public class DelegateCommand : ICommand
    {
        private readonly Action<object> _action;
        private readonly Predicate<object> _predicate;
        public DelegateCommand(Action<object> action, Predicate<object> predicate = null)
        {
            this._predicate = predicate;
            this._action = action;
        }

        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        public bool CanExecute(object parameter)
        {
            return this._predicate?.Invoke(parameter) ?? true;
        }

        public void Execute(object parameter) => this._action(parameter);
    }
}