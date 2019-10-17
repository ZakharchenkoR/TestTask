
//
namespace BLL.Model
{
    using System;
    public class TaskDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime? StartData { get; set; }
        public DateTime? EndData { get; set; }
        public int Condition { get; set; }
    }
}