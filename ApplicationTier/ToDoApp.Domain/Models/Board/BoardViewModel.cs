using System;
using System.Collections.Generic;
using System.Text;
using ToDoApp.Domain.Models.ListTask;

namespace ToDoApp.Domain.Models.Board
{
    public class BoardViewModel
    {
        public BoardResponse Board { get; set; }
        public List<ListTaskDetail> ListTasks {get; set;}
    }
}
