
namespace TasksApplication.ViewModel
{
    using System;
    using System.Windows.Input;
    using BLL.Model;
    using BLL.Services;
    using Model;
    using Settings;
    using Condition = Model.Condition;
    public class MainViewModel : BaseViewModel
    {
        #region Private Fields
        private NotifyCollection<TaskModel> _tasks;
        private Condition _conditionToAdd;
        private DateTime? _startDateToAdd;
        private DateTime? _endDateToAdd;
        private string _titleToAdd;
        private string _titleToFiltering;
        private Condition _conditionToFiltering;
        private DateTime? _startDateToFiltering;
        private DateTime? _endDateToFiltering;
        private ICommand _addCommand;
        private ICommand _clearFiltersCommand;

        #endregion

        #region Constructor
        public MainViewModel(IService<TaskDto> service)
        {
            this._tasks = new NotifyCollection<TaskModel>(new ModelService(service));
            this.FilterCollection = this._tasks;
            this.StartDateToAdd = DateTime.Today;
        }

        #endregion

        #region Properties
        private NotifyCollection<TaskModel> FilterCollection { get; }
        public string TitleToFiltering
        {
            get => this._titleToFiltering;
            set
            {
                this._titleToFiltering = value;
                this.Tasks = new NotifyCollection<TaskModel>(Filtering.Filter(this.FilterCollection, value, this.StartDateToFiltering, this.EndDateToFiltering, this.ConditionToFiltering));
                this.OnPropertyChanged(nameof(this.TitleToFiltering));
            }
        }
        public DateTime? EndDateToFiltering
        {
            get => this._endDateToFiltering;
            set
            {
                this._endDateToFiltering = value;
                this.Tasks = new NotifyCollection<TaskModel>(Filtering.Filter(this.FilterCollection, this.TitleToFiltering, this.StartDateToFiltering, value, this.ConditionToFiltering));
                this.OnPropertyChanged(nameof(this.EndDateToFiltering));
            }
        }
        public DateTime? StartDateToFiltering
        {
            get => this._startDateToFiltering;
            set
            {
                this._startDateToFiltering = value;
                this.Tasks = new NotifyCollection<TaskModel>(Filtering.Filter(this.FilterCollection, this.TitleToFiltering, value, this.EndDateToFiltering, this.ConditionToFiltering));
                this.OnPropertyChanged(nameof(this.StartDateToFiltering));
            }
        }
        public Condition ConditionToFiltering
        {
            get => this._conditionToFiltering;
            set
            {
                this._conditionToFiltering = value;
                this.Tasks = new NotifyCollection<TaskModel>(Filtering.Filter(this.FilterCollection, this.TitleToFiltering, this.StartDateToFiltering, this.EndDateToFiltering, value));
                this.OnPropertyChanged(nameof(this.ConditionToFiltering));
            }
        }
        public string TitleToAdd
        {
            get => this._titleToAdd;
            set
            {
                this._titleToAdd = value;
                this.OnPropertyChanged(nameof(this.TitleToAdd));
            }
        }
        public DateTime? EndDateToAdd
        {
            get => this._endDateToAdd;
            set
            {
                this._endDateToAdd = value;
                this.OnPropertyChanged(nameof(this.EndDateToAdd));
            }
        }
        public DateTime? StartDateToAdd
        {
            get => this._startDateToAdd;
            set
            {
                this._startDateToAdd = value;
                this.OnPropertyChanged(nameof(this.StartDateToAdd));
            }
        }
        public Condition ConditionToAdd
        {
            get => this._conditionToAdd;
            set
            {
                this._conditionToAdd = value;

                if (value == Condition.Done)
                {
                    this.EndDateToAdd = DateTime.Now;
                }

                this.OnPropertyChanged(nameof(this.ConditionToAdd));
            }
        }
        public NotifyCollection<TaskModel> Tasks
        {
            get => this._tasks;
            set { this._tasks = value; this.OnPropertyChanged(nameof(this.Tasks)); }
        }

        #endregion

        #region Commands

        public ICommand AddCommand =>
            this._addCommand ?? (this._addCommand = new DelegateCommand(x => this.Add(), o => 
                !string.IsNullOrEmpty(this.TitleToAdd) 
                && this.ConditionToAdd != Condition.NotFound
                && string.IsNullOrEmpty(this.TitleToFiltering) 
                && this.ConditionToFiltering == Condition.NotFound 
                && this.EndDateToFiltering == null
                && this.StartDateToFiltering == null));

        public ICommand ClearFiltersCommand =>
            this._clearFiltersCommand ?? (this._clearFiltersCommand = new DelegateCommand(x => this.ClearFilters()));

        #endregion

        #region Methods

        private void Add()
        {
            this.Tasks.AddNewItem(new TaskModel()
            {
                Title = this.TitleToAdd,
                StartData = this.StartDateToAdd,
                EndData = this.EndDateToAdd,
                Condition = this.ConditionToAdd
            });
            this.TitleToAdd = string.Empty;
            this.ConditionToAdd = Condition.NotFound;
        }

        private void ClearFilters()
        {
            this.ConditionToFiltering = Condition.Done;
            this.EndDateToFiltering = null;
            this.StartDateToFiltering = null;
            this.TitleToFiltering = null;
            this.Tasks = this.FilterCollection;
        }

        #endregion
    }
}