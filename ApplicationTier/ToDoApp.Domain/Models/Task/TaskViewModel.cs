using System;
using System.Collections.Generic;
using System.Text;
using ToDoApp.Domain.Base;
using ToDoApp.Domain.Models.Attackment;
using ToDoApp.Domain.Models.Label;
using ToDoApp.Domain.Models.User;

namespace ToDoApp.Domain.Models.Task
{
    public class TaskViewModel : EntityBaseId<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? DueDate { get; set; }
        public int? ParentId { get; set; }
        public int ListTaskId { get; set; }
        public string ListTask { get; set; }
        public List<UserResponse> AssignmentTasks { get; set; }
        public List<AttackmentResponse> Attackments { get; set; }
        public List<TaskDetail> SubTasks { get; set; }
        public List<LabelResponse> LabelTasks { get; set; }
    }
}
