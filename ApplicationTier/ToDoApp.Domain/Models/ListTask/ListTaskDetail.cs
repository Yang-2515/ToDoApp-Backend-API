using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using ToDoApp.Domain.Base;

namespace ToDoApp.Domain.Models.ListTask
{
    public class ListTaskDetail: EntityBaseId<int>
    {
        public string Name { get; set; }
    }
}
