using ToDoApp.Domain.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoApp.Domain.Models.Task
{
    public class TaskResponse: EntityBaseId<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? DueDate { get; set; }
        public int? ParentId { get; set; }
        public int ListTaskId { get; set; }
        public string ListTask { get; set; }
    }
}
