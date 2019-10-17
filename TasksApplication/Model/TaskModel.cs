
namespace TasksApplication.Model
{
    using System;
    public class TaskModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime? StartData { get; set; }
        public DateTime? EndData { get; set; }
        public Condition Condition { get; set; }
    }
}