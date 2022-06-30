
using System;
using System.Collections.Generic;
using System.Text;
using ToDoApp.Domain.Base;

namespace ToDoApp.Domain.Models.Task
{
    public class TaskDetail: EntityBaseId<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int SubTasksCount { get; set; }
        public int AttackmentsCount { get; set; }
    }
}
