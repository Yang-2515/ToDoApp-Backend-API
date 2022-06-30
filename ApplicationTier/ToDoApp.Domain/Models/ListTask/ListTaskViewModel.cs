using System;
using System.Collections.Generic;
using System.Text;
using ToDoApp.Domain.Models.Task;

namespace ToDoApp.Domain.Models.ListTask
{
    public class ListTaskViewModel
    {
        public ListTaskResponse ListTask { get; set; }
        public List<TaskDetail> Tasks { get; set; }
    }
}
