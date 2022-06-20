using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ToDoApp.Domain.Base;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ToDoApp.Domain.Entities
{
    [Table("TaskLabel")]
    public partial class TaskLabel: EntityBase<int>
    {
        public int TaskId { get; set; }
        public int LabelId { get; set; }

        [ForeignKey(nameof(LabelId))]
        [InverseProperty("TaskLabels")]
        public virtual Label Label { get; set; }
        [ForeignKey(nameof(TaskId))]
        [InverseProperty("TaskLabels")]
        public virtual Task Task { get; set; }
    }
}
