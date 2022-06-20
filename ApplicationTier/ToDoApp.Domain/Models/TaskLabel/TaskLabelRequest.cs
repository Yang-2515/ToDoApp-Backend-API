using ToDoApp.Domain.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ToDoApp.Domain.Models.TaskLabel
{
    public class TaskLabelRequest : EntityBaseId<int>
    {
        [Required]
        public int TaskId { get; set; }
        [Required]
        public int LabelId { get; set; }
    }
}
